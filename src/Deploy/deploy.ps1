$scriptDir = Split-Path ((Get-Variable MyInvocation -Scope 0).Value.MyCommand.Path)

$FrameworkKeyPath = "HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"

if((Test-Path $FrameworkKeyPath) -eq $False)
{
	Write-Error "Unable to detect framework version"
	Return
}

$FrameworkValue = Get-ItemProperty -Path $FrameworkKeyPath | select -ExpandProperty "Release"
$FrameworkNeeded = ""

if($FrameworkValue -lt 378389)
{
	Write-Error "You need at least .NET 4.5 to install Service Bouncer"
	Return
}
elseif($FrameworkValue -lt 394254)
{
	$FrameworkNeeded = "NET45"
}
elseif($FrameworkValue -lt 461308)
{
	$FrameworkNeeded = "NET461"
}
elseif($FrameworkValue -lt 528040)
{
	$FrameworkNeeded = "NET471"
}
else
{
	$FrameworkNeeded = "NET48"
}

$ServiceBouncer = Get-Process ServiceBouncer -ErrorAction SilentlyContinue
if ($ServiceBouncer) {
	Write-Host "Application Running, Attempting to Stop"
	$ServiceBouncer | Stop-Process -Force
	Write-Host "Sleeping for 10 seconds to allow for Stop"
	Start-Sleep -s 10
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

Write-Host "Deploying from framework version $FrameworkNeeded to $DeployPath"
Copy-Item "$scriptDir\Content\$FrameworkNeeded\*" $DeployPath -Force -Recurse