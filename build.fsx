#r "paket:
nuget Fake.IO.FileSystem
nuget Fake.DotNet.Cli
nuget Fake.Core.Target //"
#load ".fake/build.fsx/intellisense.fsx"


open Fake.Core
open Fake.IO
open Fake.DotNet.Cli

let buildDir = "./build"

// *** Define Targets ***
Target.create "Default" (fun _ -> 
    dotnet tool restore
    dotnet paket restore
    Trace.log "Hello there"
)

Target.create "Clean" (fun _ -> 
    Trace.log ("Cleaning dir " + buildDir)
    Shell.cleanDir buildDir
)


open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "Default"

// *** Start Build ***
Target.runOrDefault "Default"