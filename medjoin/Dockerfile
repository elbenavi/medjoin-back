#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
#WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR "/src"
COPY ["medjoin.csproj", "."]
RUN dotnet restore "medjoin.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "medjoin.csproj" -c Release -o /app/build



# Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out

FROM build AS publish
RUN dotnet publish "medjoin.csproj" -c Release -o /app/publish


#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "aspnetapp.dll"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "medjoin.dll"]