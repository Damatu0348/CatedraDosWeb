# CatedraDosWeb
Una API REST que tiene como objetivo administrar usuarios. Creada en Visual Studio Code

# Requisitos

Tener instalados .NET SDK y base de datos SQLite.
Teneren Visual Studio Code las extensiones de:  
    C#
    SQLite Viewer

# Instalación
En la consola del sistema:
Clonar el repositorio
git clone https://github.com/Damatu0348/CatedraDosWeb.git
cd CatedraDosWeb

Abrir Visual Studio Code
code .

Restaurar dependencias:
dotnet restore

Aplicar migraciones y crear base de datos SQLite
dotnet ef database update

Ejecutar el servidor
dotnet run

