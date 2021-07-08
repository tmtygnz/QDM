# Setup

if (-not(Test-Path "$PSScriptRoot\Build")){
    Write-Host "Build Folder Not Found. Creating Build Folder" -ForegroundColor Yellow
    New-Item "$PSScriptRoot\Build" -ItemType Directory
}

else {
    Write-Host "Build Folder Found." -ForegroundColor Green
    foreach($item in Get-ChildItem "$PSScriptRoot\Build"){
        Remove-Item "Build\$item" -Recurse
        Write-Host "Removing $item" -ForegroundColor Yellow
    }
}

$SolutionPath = "$PSScriptRoot\QuickDownloadManagerDesktop\QuickDownloadManagerDesktop.sln"
$BuildPath = "$PSScriptRoot\Build"

Write-Host "Running Dotnet Clean" -ForegroundColor Green
dotnet clean $SolutionPath

Write-Host "Running Dotnet Restore" -ForegroundColor Green
dotnet restore $SolutionPath

Write-Host "Building Solution" -ForegroundColor Green
dotnet publish $SolutionPath --configuration Release --runtime win10-x64 --self-contained false --output "$BuildPath\QDM"

Write-Host "Creating Archive" -ForegroundColor Green
Get-ChildItem -Path "$BuildPath\QDM" | Compress-Archive -CompressionLevel Fastest -DestinationPath "$BuildPath\QDM.zip"

if (-not(Test-Path "$BuildPath\QDM.zip")){
    Write-Host "Unable to create archive" -ForegroundColor Yellow
}

Write-Host "Done Building. Check you files here: $BuildPath" -BackgroundColor Green