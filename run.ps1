./dotnet-install.ps1 -Channel Preview
dotnet --version
dotnet restore
dotnet build
dotnet test
dotnet pack -c Release -o .\artifacts