namespace Data.Settings
{
    /// <summary>
    /// Classe que representa as configurações do MongoDB.
    /// </summary>
    public class MongoDbSettings : IMongoDbSettings
    {
        /// <summary>
        /// String de conexão com o banco de dados MongoDB.
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;

        /// <summary>
        /// Nome do banco de dados MongoDB.
        /// </summary>
        public string DatabaseName { get; set; } = string.Empty;

        /// <summary>
        /// Nome da coleção do MongoDB.
        /// </summary>
        public string CollectionName { get; set; } = string.Empty;
    }
}