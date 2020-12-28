#-------------------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
LABEL stage=build
WORKDIR /app
COPY . .
WORKDIR /app/AuthServerEfCore.Web
RUN dotnet publish "AuthServerEfCore.Web.csproj" -c Release -o /app/publish

#-------------------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 5000
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AuthServerEfCore.Web.dll"]
