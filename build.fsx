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

Target.create  "Build" (fun _ -> 
    Trace.log "============ build ============"
    !! "Frapper/*.fsproj"
      |> MSBuild.runRelease id buildDir "Build"
      |> Trace.logItems "AppBuild-Output: "
)

Target.create "Clean" (fun _ -> 
    Trace.log ("============ Cleaning dir " + buildDir + " ============")
    Shell.cleanDir buildDir
)


open Fake.Core.TargetOperators

"Clean"
  ==> "Build"

Target.runOrDefault "Build"