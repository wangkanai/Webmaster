#./dotnet-install.ps1 -Channel Current -version 3.0.100
dotnet --version
dotnet restore
dotnet build -Channel Release
dotnet test
dotnet pack -Channel Release -o .\artifacts
