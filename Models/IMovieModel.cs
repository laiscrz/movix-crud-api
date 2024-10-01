namespace Models
{
    public interface IMovieModel
    {
        string Id { get; set; }
        string Titulo { get; set; }
        string Diretor { get; set; }
        ICollection<string> Genero { get; set; }
        int AnoLancamento { get; set; }
        string Sinopse { get; set; }
    }
}
