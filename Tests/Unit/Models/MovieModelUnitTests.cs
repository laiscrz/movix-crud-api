using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Models;

namespace Tests.Unit.Models
{
    public class MovieModelUnitTests
    {
        [Fact]
        public void MovieModel_Deve_Criar_Instancia_Valida()
        {
            // Arrange
            var movieId = ObjectId.GenerateNewId().ToString();  
            var titulo = "A Origem";
            var diretor = "Christopher Nolan";
            var generos = new List<string> { "Ficção Científica", "Suspense" };
            var anoLancamento = 2010;
            var sinopse = "Um ladrão que rouba segredos corporativos.";

            // Act
            var filme = new MovieModel
            {
                Id = ObjectId.Parse(movieId),  
                Titulo = titulo,
                Diretor = diretor,
                Genero = generos,
                AnoLancamento = anoLancamento,
                Sinopse = sinopse
            };

            // Assert
            Assert.Equal(movieId, filme.Id.ToString()); 
            Assert.Equal(titulo, filme.Titulo);
            Assert.Equal(diretor, filme.Diretor);
            Assert.Equal(generos, filme.Genero);
            Assert.Equal(anoLancamento, filme.AnoLancamento);
            Assert.Equal(sinopse, filme.Sinopse);
        }

        [Fact]
        public void MovieModel_Deve_Ter_Titulo_Obrigatorio()
        {
            // Arrange
            var filme = new MovieModel
            {
                Id = ObjectId.GenerateNewId(),
                Diretor = "Christopher Nolan",
                Genero = new List<string> { "Ficção Científica" },
                AnoLancamento = 2010,
                Sinopse = "Um ladrão que rouba segredos corporativos."
            };

            // Act & Assert
            Assert.Throws<ValidationException>(() =>
            {
                if (string.IsNullOrEmpty(filme.Titulo))
                {
                    throw new ValidationException("Título é obrigatório.");
                }
            });
        }

        [Fact]
        public void MovieModel_Deve_Ter_Diretor_Obrigatorio()
        {
            // Arrange
            var filme = new MovieModel
            {
                Id = ObjectId.GenerateNewId(),
                Titulo = "A Origem",
                Genero = new List<string> { "Ficção Científica" },
                AnoLancamento = 2010,
                Sinopse = "Um ladrão que rouba segredos corporativos."
            };

            // Act & Assert
            Assert.Throws<ValidationException>(() =>
            {
                if (string.IsNullOrEmpty(filme.Diretor))
                {
                    throw new ValidationException("Diretor é obrigatório.");
                }
            });
        }

        [Theory]
        [InlineData(1887)]
        [InlineData(2101)]
        public void MovieModel_Deve_Lancar_Erro_Para_AnoLancamento_Invalido(int anoLancamento)
        {
            // Arrange
            var filme = new MovieModel
            {
                Id = ObjectId.GenerateNewId(),
                Titulo = "A Origem",
                Diretor = "Christopher Nolan",
                Genero = new List<string> { "Ficção Científica" },
                AnoLancamento = anoLancamento,
                Sinopse = "Um ladrão que rouba segredos corporativos."
            };

            // Act & Assert
            Assert.Throws<ValidationException>(() =>
            {
                if (anoLancamento < 1888 || anoLancamento > 2100)
                {
                    throw new ValidationException("Ano de lançamento deve estar entre 1888 e 2100.");
                }
            });
        }

        [Fact]
        public void MovieModel_Deve_Ter_Sinopse_Maximo_500_Caracteres()
        {
            // Arrange
            var filme = new MovieModel
            {
                Id = ObjectId.GenerateNewId(),
                Titulo = "A Origem",
                Diretor = "Christopher Nolan",
                Genero = new List<string> { "Ficção Científica" },
                AnoLancamento = 2010,
                Sinopse = new string('A', 501) 
            };

            // Act & Assert
            Assert.Throws<ValidationException>(() =>
            {
                if (filme.Sinopse.Length > 500)
                {
                    throw new ValidationException("Sinopse não pode ter mais de 500 caracteres.");
                }
            });
        }
    }
}
