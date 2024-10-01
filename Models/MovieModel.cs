using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations; 

namespace Models
{
    public class MovieModel : IMovieModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [SwaggerSchema(Title = "ID", Description = "Identificador único do filme gerado automaticamente pelo MongoDB.")]
        public string Id { get; set; } = string.Empty;

        [BsonElement("titulo")]
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres.")]
        [SwaggerSchema(Title = "Título", Description = "Título do filme.", Nullable = false)]
        public string Titulo { get; set; } = string.Empty;

        [BsonElement("diretor")]
        [Required(ErrorMessage = "O diretor é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome do diretor não pode exceder 50 caracteres.")]
        [SwaggerSchema(Title = "Diretor", Description = "Nome do diretor do filme.", Nullable = false)]
        public string Diretor { get; set; } = string.Empty;

        [BsonElement("genero")]
        [Required(ErrorMessage = "Pelo menos um gênero é obrigatório.")]
        [SwaggerSchema(Title = "Gênero", Description = "Lista de gêneros associados ao filme.", Nullable = false)]
        public ICollection<string> Genero { get; set; } = new List<string>(); 

        [BsonElement("anoLancamento")]
        [Range(1888, 2100, ErrorMessage = "O ano de lançamento deve estar entre 1888 e 2100.")]
        [SwaggerSchema(Title = "Ano de Lançamento", Description = "Ano de lançamento do filme. Deve estar entre 1888 e 2100.", Nullable = false)]
        public int AnoLancamento { get; set; }

        [BsonElement("sinopse")]
        [StringLength(500, ErrorMessage = "A sinopse não pode exceder 500 caracteres.")]
        [SwaggerSchema(Title = "Sinopse", Description = "Sinopse do filme. Limite de 500 caracteres.")]
        public string Sinopse { get; set; } = string.Empty;
    }
}
