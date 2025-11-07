# ----------------------------------
# ETAPA 1: BUILD (Construcción)
# Usa la imagen SDK para compilar el código.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# Establece el directorio de trabajo dentro del contenedor.
WORKDIR /src

# Copia solo el archivo .csproj para restaurar dependencias primero (mejora el cacheo)
# Si tienes múltiples proyectos, ajusta esto o usa COPY ["*.csproj", "./"]
COPY AppCongreso.csproj . 
RUN dotnet restore

# Copia el resto del código fuente
COPY . .

# Publica la aplicación, el resultado final va a /app/publish
# Asegúrate de usar el nombre correcto de tu archivo de proyecto .csproj
RUN dotnet publish "AppCongreso.csproj" -c Release -o /app/publish --no-restore

# ----------------------------------
# ETAPA 2: FINAL (Ejecución)
# Usa la imagen runtime más ligera para la ejecución final.
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
# El puerto 8080 es el estándar de Docker para .NET, y Render lo manejará.
ENV ASPNETCORE_URLS=http://+:8080 
WORKDIR /app
# Copia los archivos publicados desde la etapa 'build'
COPY --from=build /app/publish .

# Define el comando que se ejecuta cuando el contenedor se inicia
# Reemplaza 'NombreDeTuApp.dll' con el nombre de tu archivo .dll compilado
ENTRYPOINT ["dotnet", "AppCongreso.dll"]