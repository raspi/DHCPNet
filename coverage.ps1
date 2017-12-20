# Generate coverage file
Write-Host "Generating coverage file.."

Push-Location "$PSScriptRoot"
$covfile = "$pwd\coverage.xml"
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
	
	$args = [string]::Format('-register:"user" -target:"xunit.console.exe" -targetargs:"{0} -noshadow" -filterfile:"codecov_filter.txt" -output:"{1}"', $dll, $covfile)
	
	Write-Host "Arguments: $args"
	Write-Host "Running Opencover.."

	$stdErrLog = "$pwd/OpenCover-stderr.log"
	$stdOutLog = "$pwd/OpenCover-stdout.log"

	$process = Start-Process OpenCover.Console -Wait -PassThru -NoNewWindow -ArgumentList "$args" -RedirectStandardOutput $stdOutLog -RedirectStandardError $stdErrLog

	if ($process.ExitCode -ne 0) {
		Write-Output "ERROR: running OpenCover failed."
		Get-Content $stdOutLog
		Get-Content $stdErrLog
		Exit 1
	}
	
	Write-Host ""
	Get-Content $stdOutLog
	Write-Host ""
  
	Write-Host "Opencover finished."
}

Write-Host "Done."

Exit 0