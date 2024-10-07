using Data.Settings;
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
        /// <param name="mongoDbSettings">Configurações do MongoDB, 
        /// incluindo a string de conexão e o nome do banco de dados.</param>
        public MongoDbFactory(MongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.DatabaseName);
        }

        /// <summary>
        /// Obtém uma coleção genérica com base no nome da coleção fornecido.
        /// </summary>
        /// <typeparam name="T">Tipo do documento na coleção.</typeparam>
        /// <param name="collectionName">Nome da coleção no MongoDB.</param>
        /// <returns>Uma instância de <see cref="IMongoCollection{T}"/>.</returns>
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
