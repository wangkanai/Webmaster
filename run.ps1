./dotnet-install.ps1 -Channel Current -version 3.0.100
dotnet --version
dotnet restore
dotnet build
dotnet test
dotnet pack ./src/Webmaster/src/Webmaster.csproj -c Release -o .\artifacts