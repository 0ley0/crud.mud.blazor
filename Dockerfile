FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["crud.mud.blazor.csproj","."]
RUN dontet restore "crud.mud.blazor.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "crud.mud.blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "crud.mud.blazor.csproj" -c Release -o /app/publish


# final stage/image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "crud.mud.blazor.dll"]

