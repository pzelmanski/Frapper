﻿#r "paket:
nuget FSharp.Core 4.7.0
nuget Fake.IO.FileSystem
nuget Fake.DotNet.MsBuild
nuget Fake.Core.Target //"
#load ".fake/build.fsx/intellisense.fsx"


open Fake.Core
open Fake.IO
open Fake.DotNet
open Fake.IO.Globbing.Operators

let outputDir = "./output/"
let buildDir = outputDir + "build/"
let testDir = outputDir + "test/"

Target.create  "BuildApp" (fun _ -> 
  Trace.log "============ Build ============"
  !! "Frapper/*.fsproj"
  |> MSBuild.runRelease id buildDir "Build"
  |> Trace.logItems "AppBuild-Output: "
)

Target.create "BuildTests" (fun _ ->
  Trace.log "============ Build Test ============"
  !! "Tests/**/*.fsproj"
  |> MSBuild.runDebug id testDir "Build"
  |> Trace.logItems "TestBuild-Output: "
)

Target.create "Clean" (fun _ -> 
    Trace.log ("============ Cleaning dir " + buildDir + " ============")
    Shell.cleanDir buildDir
)

Target.create "Default" (fun _ ->
  Trace.log "Running default"
)

open Fake.Core.TargetOperators

"Clean"
  ==> "BuildApp"
  ==> "BuildTests"
  ==> "Default"

Target.runOrDefault "Default"