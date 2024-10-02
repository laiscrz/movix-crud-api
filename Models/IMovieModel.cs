using MongoDB.Bson;

namespace Models
{
    /// <summary>
    /// Interface que representa as propriedades de um modelo de filme.
    /// </summary>
    public interface IMovieModel
    {
        /// <summary>
        /// Obtém ou define o identificador único do filme.
        /// </summary>
        ObjectId Id { get; set; }

        /// <summary>
        /// Obtém ou define o título do filme.
        /// </summary>
        string Titulo { get; set; }

        /// <summary>
        /// Obtém ou define o diretor do filme.
        /// </summary>
        string Diretor { get; set; }

        /// <summary>
        /// Obtém ou define a lista de gêneros associados ao filme.
        /// </summary>
        ICollection<string> Genero { get; set; }

        /// <summary>
        /// Obtém ou define o ano de lançamento do filme.
        /// </summary>
        int AnoLancamento { get; set; }

        /// <summary>
        /// Obtém ou define a sinopse do filme.
        /// </summary>
        string Sinopse { get; set; }
    }
}

