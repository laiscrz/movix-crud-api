using Models;

namespace DTOs
{
    public class MovieRequestDTO : MovieModel
    {

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
