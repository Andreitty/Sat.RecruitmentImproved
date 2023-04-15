# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .

RUN dotnet restore "./Sat.Recruitment.API/Sat.Recruitment.API.csproj"
RUN dotnet publish "./Sat.Recruitment.API/Sat.Recruitment.API.csproj" -c release --no-restore -o /app 

# Server Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet","Sat.Recruitment.API.dll"]