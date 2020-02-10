dotnet build --output "./_BuildOutput/" --configuration Release

dotnet test --logger "html" --results-directory "./_BuildReports/UnitTests/" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Exclude="[xunit.*]*" /p:ExcludeByFile=".\**\Resources\*.cs"

dotnet tool install dotnet-reportgenerator-globaltool --tool-path _Tools

_Tools\reportgenerator.exe "-reports:.\tests\*\coverage.cobertura.xml" "-targetdir:_BuildReports\Coverage" -reporttypes:HTML;HTMLSummary

start /W /MAX _BuildReports\Coverage\index.htm

start /W _BuildReports\UnitTests

start /W run_example.bat
