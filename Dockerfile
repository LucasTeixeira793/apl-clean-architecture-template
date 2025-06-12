# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY *.sln ./

COPY Web/Web.csproj Web/
COPY CleanArchitecture.Application/CleanArchitecture.Application.csproj CleanArchitecture.Application/
COPY CleanArchitecture.Domain/CleanArchitecture.Domain.csproj CleanArchitecture.Domain/
COPY CleanArchitecture.Presentation/CleanArchitecture.Presentation.csproj CleanArchitecture.Presentation/
COPY CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj CleanArchitecture.Infrastructure/

RUN dotnet restore

COPY . .

WORKDIR /src/Web
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Web.dll"]
