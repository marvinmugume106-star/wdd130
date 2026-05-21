$projectPath = Join-Path $PSScriptRoot 'JournalApp.csproj'
if (-not (Test-Path $projectPath)) {
    Write-Error "Project file not found: $projectPath"
    exit 1
}
dotnet run --project "$projectPath"
