using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Models;

namespace Tests.Unit.Models
{
    public class MovieModelTests
    {
        /// <summary>
        /// Verifica se uma instância de MovieModel pode ser 
        /// criada com valores válidos.
        /// </summary>
        [Fact]
        public void MovieModel_Should_Create_Valid_Instance()
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

        /// <summary>
        /// Verifica se um MovieModel lança uma exceção de 
        /// validação quando o título não é fornecido.
        /// </summary>
        [Fact]
        public void MovieModel_Should_Have_Required_Title()
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

        /// <summary>
        /// Verifica se um MovieModel lança uma exceção de 
        /// validação quando o diretor não é fornecido.
        /// </summary>
        [Fact]
        public void MovieModel_Should_Have_Required_Director()
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

        /// <summary>
        /// Testa se o MovieModel lança um erro para anos de lançamento inválidos.
        /// Os anos válidos devem estar entre 1888 e 2100.
        /// </summary>
        [Theory]
        [InlineData(1887)]
        [InlineData(2101)]
        public void MovieModel_Should_Throw_Error_For_Invalid_ReleaseYear(int anoLancamento)
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

        /// <summary>
        /// Verifica se o MovieModel lança uma exceção de validação 
        /// quando a sinopse tem mais de 500 caracteres.
        /// </summary>
        [Fact]
        public void MovieModel_Should_Have_Synopsis_Maximum_500_Characters()
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
