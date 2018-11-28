dotnet ../sonar-scanner-msbuild/SonarScanner.MSBuild.dll begin /k:core2 /n:Core2 /v:1.0 /d:sonar.login=admin /d:sonar.password=admin /d:sonar.host.url=http://127.0.0.1:9000
dotnet build
dotnet ../sonar-scanner-msbuild/SonarScanner.MSBuild.dll end /d:sonar.login=admin /d:sonar.password=admin