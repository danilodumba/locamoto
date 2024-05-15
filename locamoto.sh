docker-compose up -d

cd src/Infraestructure/Locamoto.Infra.PostgreSql
dotnet ef database update

cd ..
cd ..
cd ..

dotnet test