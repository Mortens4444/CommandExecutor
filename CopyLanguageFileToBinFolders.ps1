$sourceFile = ".\packages\Mtf.Windows.Forms.LanguageService.1.0.4\lib\net48\Languages.ods"

$destinationDirs = @()
$destinationDirs += Get-ChildItem .\CommandExecutor\bin -Directory -Recurse
$destinationDirs += Get-ChildItem .\CommandSender\bin -Directory -Recurse
	
foreach ($dir in $destinationDirs) {
    $destinationPath = Join-Path -Path $dir.FullName -ChildPath (Split-Path -Leaf $sourceFile)
    Copy-Item -Path $sourceFile -Destination $destinationPath -Force
}