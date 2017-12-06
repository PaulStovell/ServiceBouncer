$scriptDir = Split-Path ((Get-Variable MyInvocation -Scope 0).Value.MyCommand.Path)

if($FrameworkNeeded -eq $null)
{
    $FrameworkNeeded = "NET461"
}

$ServiceBouncer = Get-Process ServiceBouncer -ErrorAction SilentlyContinue
if ($ServiceBouncer) {
    Write-Host "Application Running, Attempting to Stop"
    $ServiceBouncer | Stop-Process -Force
}
else
{
    Write-Host "Application Not Running"
}

if(Test-Path $DeployPath)
{
    Write-Host "Removing Directory Found at $DeployPath"
    Remove-Item $DeployPath -Force -Recurse
    Start-Sleep -s 2
}

Write-Host "Creating Directory at $DeployPath"
New-Item $DeployPath -Type container

Write-Host "Deploying from Content\$FrameworkNeeded to $DeployPath"
Copy-Item "$scriptDir\Content\$FrameworkNeeded\*" $DeployPath -Force -Recurse