# test rabbit
## using docker

#### 拉下最新docker rabbitmq
> docker pull rabbitmq

####  執行docker rabbitmq
> docker run -d -p 5672:5672 --name rabbit rabbitmq

預設帳號 `guest` 

預設密碼 `guest`


#### 拉下最新docker rabbitmq management
> docker pull rabbitmq:management

#### 執行docker rabbitmq management
> docker run -d --name rabbit-mgmt -p 15672:15672 rabbitmq:management

打開瀏覽器，輸入 http://localhost:15672


#### 顯示docker info
> docker logs rabbit


# 執行 SonarQube
ref. https://oomusou.io/sonarqube/netcore-docker/

> docker run -d --name sonarqube -p 9000:9000 -p 9092:9092 sonarqube

By default you can login as admin with password admin

> curl https://github.com/SonarSource/sonar-scanner-msbuild/releases/download/4.4.2.1543/sonar-scanner-msbuild-4.4.2.1543-netcoreapp2.0.zip -o sonar-scanner-msbuild.zip

As dotnet core projects (.csproj) will not have <ProjectGuid>...</ProjectGuid> tag specified in the default template this needs to be manually added.

# scanner.sh
dotnet ../sonar-scanner-msbuild/SonarScanner.MSBuild.dll begin /k:core2 /n:Core2 /v:1.0 /d:sonar.login=admin /d:sonar.password=admin /d:sonar.host.url=http://127.0.0.1:9000
dotnet build
dotnet ../sonar-scanner-msbuild/SonarScanner.MSBuild.dll end /d:sonar.login=admin /d:sonar.password=admin