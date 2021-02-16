FROM mcr.microsoft.com/dotnet/runtime:5.0

RUN apt-get install -y postgresql-client 

WORKDIR /server

COPY run.sh ./

ENTRYPOINT server/run.sh