# ASP.NET Core MVC
## Instrucciones 📖
### Versión de Dotnet 5.0.102
### Instalación 🔨
##### Requisitos 
- Tener Instalado [Dotnet](https://dotnet.microsoft.com/download/dotnet/5.0)
- Tener Instalado [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
```sh
$ git clone https://github.com/antonioolvera1995/ASP.NET.CORE.MVC.git
```
### Iniciar 🚀
- Iniciar migración de la base de datos
```bash
$ Add-Migration InitialCreate
$ Update-Database
```
- Lanzar el servidor
```bash
$ dotnet run
```
### Uso
- Abrir http://localhost:5000/
- Dirígete a Sign In
- Pulsa sobre Create new 
- Rellena los campos y pulsa sobre Create
- Ya puedes editar o eliminar el registo
