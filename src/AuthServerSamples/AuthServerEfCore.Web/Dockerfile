#-------------------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
# update 
RUN apt-get update && apt-get install -y \
  ca-certificates \
  curl

ARG NODE_VERSION=14.17.0
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs
RUN npm install
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
