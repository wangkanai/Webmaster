./dotnet-install.ps1 -Channel LTS
dotnet --version
dotnet restore
dotnet build
dotnet test
dotnet pack -c Release -o .\artifacts