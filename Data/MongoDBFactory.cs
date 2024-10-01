using MongoDB.Driver;

namespace Data
{
    /// <summary>
    /// Classe responsável por criar e gerenciar a conexão com o banco de dados MongoDB.
    /// </summary>
    public class MongoDbFactory
    {
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Construtor que inicializa uma nova instância da classe <see cref="MongoDbFactory"/>.
        /// </summary>
        /// <param name="mongoDbSettings">Configurações do MongoDB.</param>
        public MongoDbFactory(MongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.DatabaseName);
        }

        /// <summary>
        /// Obtém a instância do banco de dados MongoDB.
        /// </summary>
        /// <returns>Uma instância de <see cref="IMongoDatabase"/>.</returns>
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
