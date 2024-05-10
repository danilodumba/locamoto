using Locamoto.Domain.Core;
using Locamoto.Infra.MongoDB.Contexts;
using MongoDB.Driver;

namespace Locamoto.Infra.MongoDB.Core;

public abstract class RepositoryBase<T> where T: class
{
    readonly string _connectionString;
    readonly IMongoDatabase _mongoDatabase;
    protected readonly IMongoCollection<T> _dbSet;

    public RepositoryBase(string connectionString)
    {
        _connectionString = connectionString;

         var client = new MongoClient(_connectionString);
        _mongoDatabase = client.GetDatabase(MongoContextSchema.DefualtDatabase);
        _dbSet = _mongoDatabase.GetCollection<T>(typeof(T).Name);
    }
}
