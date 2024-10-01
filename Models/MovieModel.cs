using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class MovieModel : IMovieModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("titulo")]
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [BsonElement("diretor")]
        [Required(ErrorMessage = "O diretor é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome do diretor não pode exceder 50 caracteres.")]
        public string Diretor { get; set; } = string.Empty;

        [BsonElement("genero")]
        [Required(ErrorMessage = "Pelo menos um gênero é obrigatório.")]
        public ICollection<string> Genero { get; set; } = new List<string>(); 

        [BsonElement("anoLancamento")]
        [Range(1888, 2100, ErrorMessage = "O ano de lançamento deve estar entre 1888 e 2100.")]
        public int AnoLancamento { get; set; }

        [BsonElement("sinopse")]
        [StringLength(500, ErrorMessage = "A sinopse não pode exceder 500 caracteres.")]
        public string Sinopse { get; set; } = string.Empty;
    }
}
