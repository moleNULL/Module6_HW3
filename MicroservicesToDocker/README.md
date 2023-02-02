#!!!!!SETUP STEPS!!!!!
Update host file on your PC
   like this instruction https://www.nublue.co.uk/guides/edit-hosts-file/#:~:text=In%20Windows%2010%20the%20hosts,%5CDrivers%5Cetc%5Chosts.

Need to path these lines

    127.0.0.1 www.alevelwebsite.com
    0.0.0.0 www.alevelwebsite.com
    192.168.0.1 www.alevelwebsite.com

#docker
docker-compose build --no-cache

docker-compose up

#Add-Migration
dotnet ef --startup-project MicroservicesToDocker migrations add InitialMigration --project MicroservicesToDocker

#Update-Migration
dotnet ef --startup-project MicroservicesToDocker database update InitialMigration --project MicroservicesToDocker

#Remove-Migration
dotnet ef --startup-project MicroservicesToDocker migrations remove --project MicroservicesToDocker -f