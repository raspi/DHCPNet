# Generate coverage file
Write-Host "Generating coverage file.."

Push-Location "$PSScriptRoot"
$covfile = "$pwd/coverage.xml"
Write-Host "Coverage file: $covfile"
Push-Location "unittest"

Write-Host "Dir: $pwd"

Get-ChildItem . -Recurse -Filter "Test.dll" | Where-Object DirectoryName -NotLike "*obj*" | foreach {
  $dll = $_.Fullname
  Write-Host "DLL: $dll"
  $targetargs = "$dll -verbose -noshadow"
  Write-Host "Arguments: $targetargs"
  Write-Host "Running Opencover.."
  OpenCover.Console.exe -log:"All" -register:"user" -target:"xunit.console.exe" -targetargs:"$targetargs" -output:"$covfile"
  Write-Host "Opencover finished."
}
Pop-Location

Write-Host "Done."

Exit 0