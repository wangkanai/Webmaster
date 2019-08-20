./dotnet-install.ps1 -Channel Current -version 3.0.100-preview8-013656
dotnet --version
dotnet restore
dotnet build
dotnet test
dotnet pack -c Release -o .\artifacts