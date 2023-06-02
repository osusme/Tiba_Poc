FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_18.x | bash \
    && apt-get install nodejs -yq
RUN node --version
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY ["./Application/Application.csproj", "src/Application/"]
COPY ["./Domain/Domain.csproj", "src/Domain/"]
COPY ["./Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
COPY ["./WebUI/WebUI.csproj", "src/WebUI/"]

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "src/WebUI/WebUI.csproj"

COPY . .

# run build over the API project
WORKDIR "/src/WebUI/"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_18.x | bash \
    && apt-get install nodejs -yq
RUN node --version
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "WebUI.dll" ]