# todo.... variables
until PGPASSWORD='tom-nook-stalks' psql --host postgres --port 5432 --username murg --dbname postgres
do 
  echo "waiting on postgres"
  sleep 5
done

dotnet restore

# todo: copy exe build artifact and just run that
dotnet run --server-urls "https://*:5001"