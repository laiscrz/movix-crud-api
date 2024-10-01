using Models;

namespace Tests.Unit
{
    public class TestesMovieModel
    {
        [Fact]
        public void MovieModel_Deve_Criar_Instancia_Valida()
        {
            // Arrange
            var movieId = "1";
            var titulo = "A Origem";
            var diretor = "Christopher Nolan";
            var generos = new List<string> { "Ficção Científica", "Suspense" };
            var anoLancamento = 2010;
            var sinopse = "Um ladrão que rouba segredos corporativos.";

            // Act
            var filme = new MovieModel
            {
                Id = movieId,
                Titulo = titulo,
                Diretor = diretor,
                Genero = generos,
                AnoLancamento = anoLancamento,
                Sinopse = sinopse
            };

            // Assert
            Assert.Equal(movieId, filme.Id);
            Assert.Equal(titulo, filme.Titulo);
            Assert.Equal(diretor, filme.Diretor);
            Assert.Equal(generos, filme.Genero);
            Assert.Equal(anoLancamento, filme.AnoLancamento);
            Assert.Equal(sinopse, filme.Sinopse);
        }
    }
}
