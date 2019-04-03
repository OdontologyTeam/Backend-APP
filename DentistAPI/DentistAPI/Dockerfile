FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DentistAPI/DentistAPI.csproj", "DentistAPI/"]
RUN dotnet restore "DentistAPI/DentistAPI.csproj"
COPY . .
WORKDIR "/src/DentistAPI"
RUN dotnet build "DentistAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DentistAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DentistAPI.dll"]