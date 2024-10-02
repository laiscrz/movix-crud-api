using Models;

namespace DTOs
{
    public class MovieResponseDTO
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public ICollection<string> Genero { get; set; }
        public int AnoLancamento { get; set; }
        public string Sinopse { get; set; }

        public MovieResponseDTO(MovieModel movie)
        {
            Id = movie.Id.ToString();  
            Titulo = movie.Titulo;
            Diretor = movie.Diretor;
            Genero = movie.Genero;
            AnoLancamento = movie.AnoLancamento;
            Sinopse = movie.Sinopse;
        }
    }
}
