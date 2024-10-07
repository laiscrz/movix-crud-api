using MongoDB.Driver;
using Data.Settings;
using Models;

namespace Data
{
    /// <summary>
    /// O <see cref="MongoDbContext"/> centraliza o acesso às coleções do banco de dados MongoDB.
    /// Ele é responsável por configurar a conexão com o banco e fornecer acesso às coleções.
    /// 
    /// Similar ao <see cref="DbContext"/> do Entity Framework. Facilita a 
    /// injeção de dependência e promove a separação entre lógica 
    /// de acesso a dados e lógica de negócios.
    /// </summary>
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoDbSettings _mongoDbSettings;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="MongoDbContext"/> com base nas configurações do MongoDB.
        /// </summary>
        /// <param name="mongoDbSettings">Configurações do MongoDB contendo a string de conexão e o nome do banco de dados.</param>
        public MongoDbContext(MongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);

            _database = client.GetDatabase(mongoDbSettings.DatabaseName);

            _mongoDbSettings = mongoDbSettings;
        }

        /// <summary>
        /// Obtém a coleção de filmes do MongoDB usando o nome da coleção definido no appsettings.json.
        /// </summary>
        /// <returns>Uma instância da coleção de filmes.</returns>
        public IMongoCollection<MovieModel> Movies => _database.GetCollection<MovieModel>(_mongoDbSettings.CollectionName);

    }
}
