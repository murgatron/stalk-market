# stalk-market

Tool for tracking turnip prices &amp; displaying visualizations. 

If you have no idea what this means, check out _Animal Crossing: New Horizons_. 

# about

.NET 5 backend/API, react frontend
postgres container for persistence. 
written on WSL2 Ubuntu with VSCode remote 

# setup

you will need

- nodejs lts
- dotnet 5 sdk or runtime
- docker (for postgres), optionally for the rest of the app
- pgadmin (optional) - can be helpful if you want to check out the pg instance

# run

to run without containers

```
./run.sh
```

to run with containers

```
docker-compose up -d
```

on WSL you may need to `sudo` the above command. 