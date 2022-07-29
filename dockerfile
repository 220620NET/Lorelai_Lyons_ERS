FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /app

COPY . .

RUN dotnet publish ERS_API --configuration Release -o ./publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as run

WORKDIR /app

COPY --from=build /app/publish .

CMD [ "dotnet", "ERS_API.dll" ]