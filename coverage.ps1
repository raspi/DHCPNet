# Generate coverage file
Write-Host "Generating coverage file.."

Push-Location "$PSScriptRoot"
$covfile = "$pwd/coverage.xml"
Write-Host "Coverage file: $covfile"
Push-Location "unittest"

Write-Host "Dir: $pwd"

Write-Host "Generating file list.."
$files = Get-ChildItem . -Recurse -File "Test.dll" | Where-Object DirectoryName -NotLike "*obj*" 
Write-Host "Done."

Pop-Location

Write-Host "Generating '$covfile'.."
$files | foreach {
  $dll = $_.Fullname | Resolve-Path -Relative
  Write-Host "DLL: $dll"
  $targetargs = "$dll -verbose -noshadow"
  Write-Host "Arguments: $targetargs"
  Write-Host "Running Opencover.."
  
  OpenCover.Console.exe -log:"All" -register:"user" -target:"xunit.console.exe" -targetargs:"$targetargs" -filterfile:".\codecov_filter.txt" -output:"$covfile"

  Write-Host "Opencover finished."
}

Write-Host "Done."

Exit 0