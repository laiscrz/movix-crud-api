using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace Models
{
    /// <summary>
    /// Representa um modelo de filme com várias propriedades.
    /// </summary>
    public class MovieModel : IMovieModel
    {
        /// <summary>
        /// Obtém ou define o identificador único do filme gerado pelo MongoDB.
        /// </summary>
        [BsonId]
        [SwaggerSchema(Title = "ID", Description = "Identificador único do filme gerado automaticamente pelo MongoDB.")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        /// <summary>
        /// Obtém ou define o título do filme.
        /// </summary>
        [BsonElement("titulo")]
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres.")]
        [SwaggerSchema(Title = "Título", Description = "Título do filme.", Nullable = false)]
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o diretor do filme.
        /// </summary>
        [BsonElement("diretor")]
        [Required(ErrorMessage = "O diretor é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome do diretor não pode exceder 50 caracteres.")]
        [SwaggerSchema(Title = "Diretor", Description = "Nome do diretor do filme.", Nullable = false)]
        public string Diretor { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a lista de gêneros associados ao filme.
        /// </summary>
        [BsonElement("genero")]
        [Required(ErrorMessage = "Pelo menos um gênero é obrigatório.")]
        [SwaggerSchema(Title = "Gênero", Description = "Lista de gêneros associados ao filme.", Nullable = false)]
        public ICollection<string> Genero { get; set; } = new List<string>();

        /// <summary>
        /// Obtém ou define o ano de lançamento do filme.
        /// </summary>
        [BsonElement("anoLancamento")]
        [Range(1888, 2100, ErrorMessage = "O ano de lançamento deve estar entre 1888 e 2100.")]
        [SwaggerSchema(Title = "Ano de Lançamento", Description = "Ano de lançamento do filme. Deve estar entre 1888 e 2100.", Nullable = false)]
        public int AnoLancamento { get; set; }

        /// <summary>
        /// Obtém ou define a sinopse do filme.
        /// </summary>
        [BsonElement("sinopse")]
        [StringLength(500, ErrorMessage = "A sinopse não pode exceder 500 caracteres.")]
        [SwaggerSchema(Title = "Sinopse", Description = "Sinopse do filme. Limite de 500 caracteres.")]
        public string Sinopse { get; set; } = string.Empty;

        public MovieModel(string titulo, string diretor, ICollection<string> genero, int anoLancamento, string sinopse)
        {
            Titulo = titulo;
            Diretor = diretor;
            Genero = genero ?? new List<string>();
            AnoLancamento = anoLancamento;
            Sinopse = sinopse;
        }
    }
}
