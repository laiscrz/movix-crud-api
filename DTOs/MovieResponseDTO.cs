using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace DTOs
{
    /// <summary>
    /// Representa o DTO de resposta para o modelo de filme.
    /// Utilizado para retornar as informações de um filme ao usuário.
    /// <para>
    /// O campo Id é tratado como uma string para facilitar a leitura e a utilização na API,
    /// embora seja originalmente um ObjectId gerado pelo MongoDB.
    /// </para>
    /// </summary>
    [SwaggerSchema("Representa o DTO de resposta para o modelo de filme.")]
    public class MovieResponseDTO
    {
        /// <summary>
        /// Identificador único do filme, convertido de ObjectId (MongoDB) para string
        /// para melhor legibilidade e interação na API.
        /// </summary>
        [SwaggerSchema(
            Title = "ID do Filme",
            Description = "Identificador único do filme. Originalmente um ObjectId gerado pelo MongoDB, mas convertido para string para melhor leitura e utilização na API.")]
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public string? Id { get; set; }

        /// <summary>
        /// Título do filme.
        /// </summary>
        [SwaggerSchema(Title = "Título", Description = "Título do filme.")]
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres.")]
        public string? Titulo { get; set; }

        /// <summary>
        /// Nome do diretor do filme.
        /// </summary>
        [SwaggerSchema(Title = "Diretor", Description = "Nome do diretor do filme.")]
        [Required(ErrorMessage = "O diretor é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome do diretor não pode exceder 50 caracteres.")]
        public string? Diretor { get; set; }

        /// <summary>
        /// Lista de gêneros associados ao filme.
        /// </summary>
        [SwaggerSchema(Title = "Gênero", Description = "Lista de gêneros associados ao filme.")]
        [Required(ErrorMessage = "Pelo menos um gênero é obrigatório.")]
        public ICollection<string>? Genero { get; set; }

        /// <summary>
        /// Ano de lançamento do filme.
        /// </summary>
        [SwaggerSchema(
            Title = "Ano de Lançamento",
            Description = "Ano de lançamento do filme. O valor deve estar entre 1888 e 2100.")]
        [Required(ErrorMessage = "O ano de lançamento é obrigatório.")]
        [Range(1888, 2100, ErrorMessage = "O ano de lançamento deve estar entre 1888 e 2100.")]
        public int AnoLancamento { get; set; }

        /// <summary>
        /// Sinopse do filme.
        /// </summary>
        [SwaggerSchema(Title = "Sinopse", Description = "Sinopse do filme. Limite de 500 caracteres.")]
        [StringLength(500, ErrorMessage = "A sinopse não pode exceder 500 caracteres.")]
        public string? Sinopse { get; set; }

        
    }
}
