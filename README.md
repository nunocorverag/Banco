#GameStore
##Starting SQL Server 2022
```Powershell
$sa_password="SA PASSWORD GOES HERE"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -d -v sqlvolume:/var/opt/mssql --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

#Setting User Secret
$sa_password=SA PASSWORD HERE"