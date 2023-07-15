FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["crud.mud.blazor.csproj","."]
RUN dotnet restore "crud.mud.blazor.csproj"
COPY . ./
WORKDIR "/src"
RUN dotnet build "crud.mud.blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "crud.mud.blazor.csproj" -c Release -o /app/publish


# final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "crud.mud.blazor.dll"]


