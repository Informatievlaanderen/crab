#r "paket:
version 5.226.0
framework: netstandard20
source https://api.nuget.org/v3/index.json
nuget Be.Vlaanderen.Basisregisters.Build.Pipeline 3.0.0 //"

#load "packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/build-generic.fsx"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO.FileSystemOperators
open ``Build-generic``

let assemblyVersionNumber = (sprintf "%s.0")
let nugetVersionNumber = (sprintf "%s")

let build = buildSolution assemblyVersionNumber
let test = testSolution
let publish = publishSolution assemblyVersionNumber
let pack = packSolution nugetVersionNumber

// Library ------------------------------------------------------------------------

Target.create "Lib_Build" (fun _ -> build "Be.Vlaanderen.Basisregisters.Crab")
Target.create "Lib_Test" (fun _ -> test "Be.Vlaanderen.Basisregisters.Crab")
Target.create "Lib_Publish" (fun _ -> publish "Be.Vlaanderen.Basisregisters.Crab")
Target.create "Lib_Pack" (fun _ -> pack "Be.Vlaanderen.Basisregisters.Crab")

// --------------------------------------------------------------------------------

Target.create "Test" ignore

Target.create "PublishLibrary" ignore
Target.create "PublishAll" ignore

Target.create "PackageMyGet" ignore
Target.create "PackageAll" ignore

// Publish ends up with artifacts in the build folder
"DotNetCli" ==> "Clean" ==> "Restore" ==> "Lib_Build" ==> "Lib_Test" ==> "Lib_Publish" ==> "PublishLibrary"
"Lib_Test" ==> "Test"
"PublishLibrary" ==> "PublishAll"

// Package ends up with local NuGet packages
"PublishLibrary" ==> "Lib_Pack" ==> "PackageMyGet"
"PackageMyGet" ==> "PackageAll"

Target.runOrDefault "Lib_Build"
