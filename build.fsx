#r "paket:
nuget FSharp.Core 4.7.0
nuget Fake.IO.FileSystem
nuget Fake.DotNet.MsBuild
nuget Fake.Core.Target //"
#load ".fake/build.fsx/intellisense.fsx"


open Fake.Core
open Fake.IO
open Fake.DotNet
open Fake.IO.Globbing.Operators

let buildDir = "./build"

// *** Define Targets ***
Target.create  "Default" (fun _ -> 
    Trace.log "============ Hello there ============"
)

Target.create "Clean" (fun _ -> 
    Trace.log ("============ Cleaning dir " + buildDir + " ============")
    Shell.cleanDir buildDir
    !! "Frapper/*.fsproj"
      |> MSBuild.runRelease id buildDir "Build"
      |> Trace.logItems "AppBuild-Output: "
)


open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "Default"

// *** Start Build ***
Target.runOrDefault "Default"