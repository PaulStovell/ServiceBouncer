#r "paket: groupref BuildTools //"
#load "./.fake/build.fsx/intellisense.fsx"

open System.IO
open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.DotNet

let currentDirectory = new DirectoryInfo(System.Environment.CurrentDirectory)
let outputDir = new DirectoryInfo(currentDirectory.FullName @@ "Output")
let srcDir = new DirectoryInfo(currentDirectory.FullName @@ "src")
let buildOutput =  new DirectoryInfo(srcDir.FullName @@ "ServiceBouncer" @@ "bin" @@ "Release")

Target.create "Clean" (fun _ ->
    printfn "Clean & Ensure Output Directory"
    DirectoryInfo.ensure outputDir
)

Target.create "Build" (fun _ ->
    let setParams framework (defaults:MSBuildParams) = { defaults with Verbosity = Some(Quiet)
                                                                       Targets = ["Clean,Rebuild"]
                                                                       Properties = [
                                                                                        "Optimize", "True"
                                                                                        "DebugSymbols", "True"
                                                                                        "Configuration", (sprintf "Release%s" framework)
                                                                                    ]
                                                       }

    MSBuild.build (setParams "NET45") (srcDir.FullName @@ "ServiceBouncer.sln")
    MSBuild.build (setParams "NET461") (srcDir.FullName @@ "ServiceBouncer.sln")
)

Target.create "Package" (fun _ ->
    Zip.createZip buildOutput.FullName (outputDir.FullName @@ "ServiceBouncer.zip") "" Zip.DefaultZipLevel false ((DirectoryInfo.getMatchingFilesRecursive "*.exe" buildOutput) |> Array.map(fun x -> x.FullName))

    let nuspec = (srcDir.FullName @@ "Deploy" @@ "ServiceBouncer.nuspec")
    let nugetExePath = currentDirectory.FullName @@ "packages" @@ "buildtools" @@ "NuGet.CommandLine" @@ "tools" @@ "NuGet.exe"
    let args = sprintf @"pack ""%s"" -OutputDirectory ""%s"" -Properties Configuration=%s -NoPackageAnalysis -BasePath %s" nuspec outputDir.FullName "Release" srcDir.FullName

    let result = Process.execWithResult ((fun info -> { info with FileName = nugetExePath
                                                                  WorkingDirectory = srcDir.FullName
                                                                  Arguments = args }) >> Process.withFramework) (System.TimeSpan.FromMinutes 5.)

    if result.ExitCode <> 0 || result.Errors.Length > 0 then
        failwithf "Error during NuGet package creation. %s %s\r\n%s" nugetExePath args (String.toLines result.Errors)
)

Target.create "Default" ignore

"Clean" ==> "Build" ==> "Package" ==> "Default" |> ignore

Target.runOrDefault "Default"
