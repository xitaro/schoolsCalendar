#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

#Copy csproj e restaurar as camadas
COPY *.csproj ./
RUN dotnet restore

# Copia tudo e builda
COPY . ./
RUN dotnet publish -c Release -o out

# Build com a imagem do runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Usa porta dinâmica do Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet SchoolsCalendar1.dll
