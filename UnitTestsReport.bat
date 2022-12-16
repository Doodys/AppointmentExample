SET /A RANDOM_BUILD_NUMBER=%RANDOM% * 100 / 32768 + 1
dotnet tool install --global dotnet-reportgenerator-globaltool
cd Appointment.UnitTests
dotnet tool install -g coverlet.console
dotnet add package coverlet.collector
dotnet build 
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coveragereport/%RANDOM_BUILD_NUMBER%" -reporttypes:Html
coverlet .\bin\Debug\net6.0\Appointment.UnitTests.dll --target "dotnet" --targetargs "test --no-build"
cmd /k