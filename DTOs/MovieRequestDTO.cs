using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;

namespace DTOs
{
    /// <summary>
    /// Representa o DTO de requisição para o modelo de filme.
    /// Este DTO é utilizado para receber informações sobre um filme ao criar ou atualizar um registro,
    /// sem incluir o ID, pois ele é gerado automaticamente pelo MongoDB.
    /// </summary>
    public class MovieRequestDTO 
    {
        /// <summary>
        /// Obtém ou define o título do filme.
        /// Este campo é obrigatório e deve ter no máximo 100 caracteres.
        /// </summary>
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o diretor do filme.
        /// Este campo é obrigatório e deve ter no máximo 50 caracteres.
        /// </summary>
        [Required(ErrorMessage = "O diretor é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome do diretor não pode exceder 50 caracteres.")]
        public string Diretor { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a lista de gêneros associados ao filme.
        /// Este campo é obrigatório e deve conter pelo menos um gênero.
        /// </summary>
        [Required(ErrorMessage = "Pelo menos um gênero é obrigatório.")]
        public ICollection<string> Genero { get; set; } = new List<string>();

        /// <summary>
        /// Obtém ou define o ano de lançamento do filme.
        /// Este campo deve estar entre 1888 e 2100.
        /// </summary>
        [Range(1888, 2100, ErrorMessage = "O ano de lançamento deve estar entre 1888 e 2100.")]
        public int AnoLancamento { get; set; }

        /// <summary>
        /// Obtém ou define a sinopse do filme.
        /// Este campo deve ter no máximo 500 caracteres.
        /// </summary>
        [StringLength(500, ErrorMessage = "A sinopse não pode exceder 500 caracteres.")]
        public string Sinopse { get; set; } = string.Empty;

        /// <summary>
        /// Converte o DTO de requisição em um modelo de filme.
        /// Este método é útil para transformar as informações recebidas da API em um objeto do tipo <see cref="MovieModel"/>.
        /// </summary>
        /// <returns>Um objeto <see cref="MovieModel"/> representando o filme.</returns>
        public MovieModel ToModel()
        {
            return new MovieModel
            {
                Titulo = this.Titulo,
                Diretor = this.Diretor,
                Genero = this.Genero,
                AnoLancamento = this.AnoLancamento,
                Sinopse = this.Sinopse
            };

        }
    }
}
