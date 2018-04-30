$configuration = "Release"
rm bin -r -fo -ErrorAction Ignore
$timestamp = Get-Date -Format yyMMddHHmmss
dotnet pack --configuration $configuration --include-symbols

$path = ".\bin\$configuration\Symbols\"
If(!(test-path $path))
{
      New-Item -ItemType Directory -Force -Path $path
}

get-childitem -path ".\bin\$configuration\" -filter "*.symbols.nupkg" | move-item -Destination ".\bin\$configuration\Symbols\"
pause