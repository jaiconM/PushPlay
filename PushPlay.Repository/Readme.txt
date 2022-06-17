
Primeiro criar a base de dados e atualizar a connectionString em PushPlay.Api > appsettings.json

- via Package Manager Console
Para instalar as ferramentas para criar migrations e atualizar a base de dados:
 > Install-Package Microsoft.EntityFrameworkCore.Tools

 Para criar a migration:
 > Add-Migration NomeDaMigration

 Para atualizar a base de dados (aplicar as migrations):
 > Update-Database