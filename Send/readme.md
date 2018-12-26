# 執行方式

## 開啟Docker

服務啟用

`docker run -d --hostname my-rabbit --name rabbit -p 5672:5672 rabbitmq:3`

管理介面

`docker run -d --hostname my-rabbit --name some-rabbit-mgmt -p 15672:15672 rabbitmq:3-management`