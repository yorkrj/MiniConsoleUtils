# Install script for MiniConsoleUtils

$ErrorActionPreference = "Stop"

# Configuration
$installDir = "C:\tools"
$publishDir = ".\publish"

Write-Host "Starting installation of MiniConsoleUtils..." -ForegroundColor Cyan

# Create installation directory if it doesn't exist
if (-not (Test-Path $installDir)) {
    Write-Host "Creating installation directory: $installDir" -ForegroundColor Yellow
    New-Item -ItemType Directory -Path $installDir -Force | Out-Null
}

# Clean and create publish directory
if (Test-Path $publishDir) {
    Remove-Item -Path $publishDir -Recurse -Force
}
New-Item -ItemType Directory -Path $publishDir -Force | Out-Null

# Get all project files
$projects = Get-ChildItem -Path . -Filter "*.csproj" -Recurse

# Build and publish each project
foreach ($project in $projects) {
    $projectName = $project.BaseName
    Write-Host "Building $projectName..." -ForegroundColor Yellow
    
    # Create project-specific publish directory
    $projectPublishDir = Join-Path $publishDir $projectName
    New-Item -ItemType Directory -Path $projectPublishDir -Force | Out-Null
    
    # Publish the project
    dotnet publish $project.FullName -c Release -o $projectPublishDir
    
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Build failed for $projectName!" -ForegroundColor Red
        exit 1
    }
}

# Copy build products to install directory
Write-Host "Installing tools..." -ForegroundColor Yellow
foreach ($project in $projects) {
    $projectName = $project.BaseName
    $projectPublishDir = Join-Path $publishDir $projectName
    
    Copy-Item -Path "$projectPublishDir\*" -Destination $installDir -Force

    # Copy only the necessary files
    #Copy-Item -Path "$projectPublishDir\*.exe" -Destination $installDir -Force
    #Copy-Item -Path "$projectPublishDir\*.dll" -Destination $installDir -Force
    #Copy-Item -Path "$projectPublishDir\*.deps.json" -Destination $installDir -Force
    #Copy-Item -Path "$projectPublishDir\*.runtimeconfig.json" -Destination $installDir -Force
}

# Add tools directory to PATH if not already present
$currentPath = [Environment]::GetEnvironmentVariable("Path", "User")
if ($currentPath -notlike "*$installDir*") {
    Write-Host "Adding tools to PATH..." -ForegroundColor Yellow
    [Environment]::SetEnvironmentVariable("Path", "$currentPath;$installDir", "User")
    $env:Path = [System.Environment]::GetEnvironmentVariable("Path","User")
}

# Cleanup
Remove-Item -Path $publishDir -Recurse -Force

Write-Host "`nInstallation completed successfully!" -ForegroundColor Green
Write-Host "Tools have been installed to: $installDir" -ForegroundColor Green
Write-Host "`nYou may need to restart your terminal for PATH changes to take effect." -ForegroundColor Green