## Comandos
### Migraciones

     dotnet ef migrations add Migrations -p Data/ -s API/

     dotnet ef migrations add InitialCreate -p ./Data/Theater.Data.csproj -s ./API/Theater.API.csproj

     dotnet ef database update  -p ./Data/Theater.Data.csproj -s ./API/Theater.API.csproj

     dotnet ef database drop  -p ./Data/Theater.Data.csproj -s ./API/Theater.API.csproj

### Docker

     docker-compose up --build --force-recreate -d 
     docker-compose down
     docker-compose down -v

### Entity Framework

     dotnet tool install --global dotnet-ef --version 6.*

### Estructura del proyecto
Creación capas DATA, MODELS, BUSINESS y API

     dotnet new classlib -n Theater.Models -o Models -f net6.0
     dotnet new classlib -n Theater.Data -o Data -f net6.0
     dotnet new classlib -n Theater.Business -o Business -f net6.0
     dotnet new webapi -n Theater.API -o API -f net6.0
  
Creación del archivo de solución [`sln`]

     dotnet new sln -n Theater

Referencias de las capas en la solución

     dotnet sln add Models/Theater.Models.csproj
     dotnet sln add Data/Theater.Data.csproj
     dotnet sln add Business/Theater.Business.csproj
     dotnet sln add API/Theater.API.csproj

Referencias de unas capas en otras

     dotnet add Data/Theater.Data.csproj reference Models/Theater.Models.csproj
     dotnet add Business/Theater.Business.csproj reference Models/Theater.Models.csproj
     dotnet add Business/Theater.Business.csproj reference Data/Theater.Data.csproj
     dotnet add API/Theater.API.csproj reference Business/Theater.Business.csproj
     dotnet add API/Theater.API.csproj reference Data/Theater.Data.csproj
     dotnet add API/Theater.API.csproj reference Models/Theater.Models.csproj

