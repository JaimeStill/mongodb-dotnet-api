# MongoDB .NET API

https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio-code

## Install MongoDB

https://docs.microsoft.com/en-us/windows/wsl/tutorials/wsl-database#install-mongodb

## Install mongosh

https://www.mongodb.com/docs/mongodb-shell/install/

## Startup

**Terminal 1**
```bash
sudo mongod --dbpath ~/data/db
```

**Terminal 2**
```bash
mongosh
```

**Terminal 3**
```bash
cd /workspaces/mongodb-dotnet-api/BookStoreApi/
dotnet run
```