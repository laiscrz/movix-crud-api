namespace Data.Settings
{
    /// <summary>
    /// Interface para as configurações do MongoDB.
    /// </summary>
    public interface IMongoDbSettings
    {
        /// <summary>
        /// String de conexão com o banco de dados MongoDB.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Nome do banco de dados MongoDB.
        /// </summary>
        string DatabaseName { get; set; }

        /// <summary>
        /// Nome da coleção do MongoDB.
        /// </summary>
        string CollectionName { get; set; }
    }
}