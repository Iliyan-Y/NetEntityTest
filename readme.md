# Simple API with .NET

## Stack description:

- .NET MVC
- .NET Entity
- mysql

## Requirements

- dotnet ef
- docker mysql container

## Preparation

- stat the database with docker `docker run --name my-mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=root -d mysql`
- create migration
  `dotnet ef migrations add CreateInitial`
- update the database
  `dotnet ef database update`
-

## How to run:

- comming soon 