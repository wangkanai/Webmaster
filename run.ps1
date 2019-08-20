./dotnet-install.ps1 -version latest
dotnet --version
dotnet restore
dotnet build
dotnet test
dotnet pack -c Release -o .\artifacts