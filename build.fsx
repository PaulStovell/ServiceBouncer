#r @"packages/FAKE/tools/FakeLib.dll"

open Fake
open System
open System.IO

let outputDir = currentDirectory @@ "Output"
let srcDir = currentDirectory @@ "src"
let buildMode = getBuildParamOrDefault "buildMode" "Release"

Target "Clean" (fun _ -> 
    printfn "Clean & Ensure Output Directory"
    CleanDir outputDir
)

Target "Build" (fun _ ->
    let setParams defaults = { defaults with Verbosity = Some(Quiet)
                                             Targets = ["Clean,Rebuild"]
                                             Properties = [
                                                            "Optimize", "True"
                                                            "DebugSymbols", "True"
                                                            "Configuration", buildMode
                                                          ]
                             }

    build setParams (srcDir @@ "ServiceBouncer.sln")
)

Target "Package" (fun _ ->
    let buildOutput = srcDir @@ "ServiceBouncer" @@ "bin" @@ "Release"
    CreateZip buildOutput (outputDir @@ "ServiceBouncer.zip") "" DefaultZipLevel false (Directory.GetFiles(buildOutput, "*.exe", SearchOption.AllDirectories))
    
    let nuspec = (srcDir @@ "Deploy" @@ "ServiceBouncer.nuspec")
    let nugetExePath = findNuget (currentDirectory @@ "packages" @@ "NuGet.CommandLine")
    let args = sprintf @"pack ""%s"" -OutputDirectory ""%s"" -Properties Configuration=%s -NoPackageAnalysis -BasePath %s" nuspec outputDir buildMode srcDir
    let result = ExecProcessWithLambdas (fun info -> info.FileName <- nugetExePath; info.Arguments <- args) (TimeSpan.FromMinutes 5.) true (fun err -> traceError err) (fun _ -> ())

    if not(result = 0) then 
        failwith "Packaging Failed"
)

Target "Default" DoNothing

"Clean"
    ==> "Build"
    ==> "Package"
    ==> "Default"

RunParameterTargetOrDefault "target" "Default"
