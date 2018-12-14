FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
COPY . .

CMD export ASPNETCORE_URLS=http://*:$PORT && dotnet AdvancedYoutube.dll
