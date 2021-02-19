FROM mcr.microsoft.com/dotnet/sdk:5.0

# dotnet images are debian by default
RUN apt-get update
RUN apt-get install -y postgresql-client

WORKDIR /server

COPY . .

RUN chmod +x run.sh

ENTRYPOINT ./run.sh