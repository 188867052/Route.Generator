$version=Get-Date -Format 'yyyyMMdd.HH.mm.ss'
dotnet build /noconlog /nologo
dotnet pack ..\Route.Generator.CLI\Route.Generator.CLI.csproj --no-build -o . -p:PackageVersion=$version
$list= dotnet tool list -g 
$generator=$list -clike '*route.generator*' | Out-String
if($generator -eq "")
{
	dotnet tool install  --global Route.Generator.CLI --add-source .\
}
else
{
	dotnet tool update --global Routes.Generator.CLI --add-source .\
}
del .\*.nupkg
routegen gen
dotnet tool uninstall --global Route.Generator.CLI