export FrameworkPathOverride=$(dirname $(which mono))/../lib/mono/4.5/
NAME=Serilog.Enrichers.AssemblyName
NUGETVERSION=1.0.8
dotnet pack $NAME -c Release /p:PackageVersion=$NUGETVERSION
dotnet nuget push $NAME/bin/Release/$NAME.$NUGETVERSION.nupkg -k $NUGETKEY -s nuget.org
