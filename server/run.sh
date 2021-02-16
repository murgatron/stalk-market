# todo.... variables
until PGPASSWORD='tom-nook-stalks' psql --host postgres --port 5432 --username murg
do 
  echo "waiting on postgres"
done

dotnet run