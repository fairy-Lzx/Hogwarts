FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["UI/Hogwarts.Admin/Hogwarts.Admin.csproj", "UI/Hogwarts.Admin/"]
RUN dotnet restore "UI/Hogwarts.Admin/Hogwarts.Admin.csproj"
COPY . .
WORKDIR "/src/UI/Hogwarts.Admin"
RUN dotnet build "Hogwarts.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hogwarts.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hogwarts.Admin.dll"]