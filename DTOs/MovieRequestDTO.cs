using Models;

namespace DTOs
{
    /// <summary>
    /// Representa o DTO de requisição para o modelo de filme.
    /// Este DTO é utilizado para receber informações sobre um filme ao criar ou atualizar um registro.
    /// Ele herda de <see cref="MovieModel"/> e inclui todas as suas propriedades.
    /// </summary>
    public class MovieRequestDTO : MovieModel
    {
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
