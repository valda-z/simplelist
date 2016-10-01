# Web App + SQL with VNET and backend system

[https://azure.microsoft.com/en-us/documentation/articles/web-sites-integrate-with-vnet/](https://azure.microsoft.com/en-us/documentation/articles/web-sites-integrate-with-vnet/)

### Scenario - use Visual Studio to deploy app

- Create simple project
    - One page with table
      retrieved from DB
    - Build, prepare to deploy
    - [https://github.com/vazvadsk/simplelist/tree/master/simplelist](https://github.com/vazvadsk/simplelist/tree/master/simplelist)

- Azure infrastructure
    - Create "Web App +
      SQL"
        - Create DB
        - Create web app

- Deploy
    - Create deployment profile
    - Deploy to azure

- Automatic deployment - bat file for deployment _

```bat
echo ####### START
set buildconfig=Release
set deployconfig=xxxx
set deploypwd=xxxxxxxxxxx
"C:\ProgramFiles (x86)\MSBuild\14.0\Bin\msbuild.exe" ASS\ASS.csproj /T:Clean;Rebuild;Publish /p:Configuration=%%buildconfig%% /p:DeployOnBuild=true /p:PublishProfile=%%deployconfig%% /p:Password=%%deploypwd%%
echo ####### DONE
```

- Create VNET for web app
    - Select web app
    - Networking -&gt; create VNET … (setup)
    - Networking -&gt; setup -&gt;
      add vnet

- Create GeoIP Service host
    - Create linux VM in VNET
        - Ubuntu 16.04
        - sudo apt update --yes
       &sudo apt dist-upgrade --yes
        - mkdir geoip
        - cd geoip
        - Docker: `wget -qO- [https://get.docker.com/](https://get.docker.com/) | sh`
        - Download geoip DB: `wget http://geolite.maxmind.com/download/geoip/database/GeoLite2-City.mmdb.gz`
        - Unzip: `gzip -d GeoLite2-City.mmdb.gz`
        - Pull image: `docker pull klauspost/geoip-service`
        - Run geoip server: `docker run --rm -p 5000:5000 -v  /home/valda/geoip/GeoLite2-City.mmdb:/data/geodb.mmdb klauspost/geoip-service`

- Update web.config file 
    - Setting key
      "GEOIPURL" has to be updated to internal IP address of linux VM
