$configuration = "Release"
$startPath = (Get-Item -Path ".\").FullName
Set-Location .\bin\$configuration
dotnet nuget push *.nupkg --config-file ../../../NugetSuperSocketNetCore.config
Set-Location .\Symbols
dotnet nuget push *.nupkg --config-file ../../../../NugetSuperSocketNetCoreSymbols.config
Set-Location $startPath
pause