# integration

a place to store black-box integration tests. 

# about 

written in jest. you'll need nodejs lts and npm

# setup

```
cd ./integration
npm install
```

# run 

for server tests. Server must be up and running separately

```
npm run inttest:server
```

for client tests. client must be up and running separately
```
npm run inttest:client
```

to run both, you crazy person. probably just spin up the containers before you run this command
```
npm run inttest
```