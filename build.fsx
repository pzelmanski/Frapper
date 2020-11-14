#r "paket:
nuget Fake.Core.Target //"
#load ".fake/build.fsx/intellisense.fsx"


open Fake.Core

// *** Define Targets ***
Target.create "Default" (fun _ -> 
    Trace.log "Default fake"
)

Target.create "Clean" (fun _ -> 
    Trace.log "--- CLEANING ---"
)

Target.create "Build" (fun _ ->
    Trace.log "--- BUILDING ---"
)

Target.create "Deploy" (fun _ ->
    Trace.log "--- DEPLOYING ---"
)

open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "Default"

// *** Start Build ***
Target.runOrDefault "Default"