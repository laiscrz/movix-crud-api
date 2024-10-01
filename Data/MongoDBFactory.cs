using MongoDB.Driver;

namespace Data
{
    public class MongoDbFactory
    {
        private readonly IMongoDatabase _database;

        public MongoDbFactory(MongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.DatabaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
