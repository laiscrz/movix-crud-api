# 🎬 Movix CRUD API

> Este projeto foi submetido como parte do Checkpoint 5° Avaliativo da disciplina de Advanced Business With .NET. 📚

**Movix** é uma API intuitiva e eficiente projetada para o gerenciamento de filmes, construída com .NET e utilizando o MongoDB como banco de dados. A Movix facilita a realização de operações de CRUD (Criar, Ler, Atualizar e Excluir) em um catálogo de filmes, permitindo que os usuários gerenciem suas coleções de maneira prática e eficaz.


## 🛠️ Funcionalidades e Endpoints da API

 Veja os principais endpoints da API para interagir com o catálogo de filmes.

| Função                                    | Endpoint                     | Método | Descrição                                                                                     |
|-------------------------------------------|------------------------------|--------|-----------------------------------------------------------------------------------------------|
| ➕ **Adicionar um Filme**                  | `POST /api/movies`          | POST   | Adiciona um novo filme ao catálogo. É necessário fornecer detalhes relevantes como título, sinopse, diretor e ano de lançamento.  |
| 📜 **Listar Todos os Filmes**             | `GET /api/movies`           | GET    | Retorna uma lista de todos os filmes cadastrados no catálogo. Permite a aplicação de filtros para busca por título ou ano.   |
| 🔍 **Obter Detalhes de Filme**            | `GET /api/movies/{id}`      | GET    | Acessa informações detalhadas de um filme específico pelo seu ID, permitindo ver todos os atributos do filme.                            |
| 📅 **Filtrar Filmes por Ano**             | `GET /api/movies/year/{year}` | GET    | Lista todos os filmes lançados em um ano específico. Ideal para facilitar a busca por períodos de lançamento.       |
| ✏️ **Atualizar um Filme**                  | `PUT /api/movies/{id}`      | PUT    | Atualiza os detalhes de um filme existente. Permite a modificação de qualquer campo, garantindo a atualização das informações conforme necessário.      |
| ❌ **Excluir um Filme**                    | `DELETE /api/movies/{id}`   | DELETE | Remove um filme do catálogo. Este endpoint deve ser utilizado com cuidado, caso o filme não seja mais necessário.          |


> [!IMPORTANT] 
> **💡 Dica:** Exemplos dos endpoints estão disponíveis no arquivo [WebApi.http](https://github.com/laiscrz/movix-crud-api/blob/main/WebApi/WebApi.http).

---

## 📂 Estrutura do Projeto

### 📦 DTOs
  - `MovieRequestDTO.cs`: Estrutura de dados para receber informações de filmes nas requisições.
  - `MovieResponseDTO.cs`: Estrutura de dados para enviar informações de filmes nas respostas.

### 🗄️ Data
  - `IMongoDbSettings.cs`: Interface para as configurações do MongoDB.
  - `MongoDBFactory.cs`: Classe responsável por criar a conexão com o MongoDB.
  - `MongoDbSettings.cs`: Classe que contém as configurações de acesso ao MongoDB.

### 🗺️ Mapping
  - `MovieMappingProfile.cs`: Perfil de mapeamento do AutoMapper para converter entre os DTOs e o modelo de domínio.

### 🎬 Models
  - `IMovieModel.cs`: Interface que define a estrutura do modelo de filme.
  - `MovieModel.cs`: Implementa a interface e representa um filme.

### 🏛️ Repositories
- **Repositories.csproj**
  - `IMovieRepository.cs`: Interface que define as operações de acesso a dados para filmes.
  - `IRepository.cs`: Interface genérica para operações de repositório.
  - `MovieRepository.cs`: Implementação da interface que contém a lógica de acesso ao banco de dados para operações de filmes.
  - `Repository.cs`: Classe que implementa a interface `IRepository`, fornecendo a lógica para as operações de repositório genéricas que podem ser reutilizadas em diferentes entidades.

### 🧪 Tests
  - **Integration**
     - **Controller**
       - `MoviesControllerIntegrationTests.cs`: Testes de integração para o controlador de filmes.
    - **Repositories**
      - `MovieRepositoryIntegrationTests.cs`: Testes de integração para o repositório de filmes.
  - **Unit**
    - **Mapping**
      - `MovieMappingProfileUnitTests.cs`: Testes unitários para o perfil de mapeamento.
    - **Models**
      - `MovieModelUnitTests.cs`: Testes unitários para o modelo de filme.

### ⚙️ WebApi
  - **Controllers**
    - `IMovieController.cs`: Interface que define as operações de CRUD para o controlador de filmes.
    - `MovieController.cs`: Controlador que gerencia as operações de CRUD para filmes.

> - **appsettings.json** ⚙️: Configurações gerais da aplicação, como a string de conexão do MongoDB..


---

## 📚 Documentação - Swagger

A documentação da API Movix está disponível na interface Swagger, que fornece uma descrição interativa de todos os endpoints e suas funcionalidades. Você pode acessar a documentação na raiz do projeto:

```https
http://localhost:5072
```

> [!NOTE]
> 📝 A documentação estará acessível apenas após o projeto ser iniciado localmente. 

---

## 💻 Tecnologias

- **IDE**: Visual Studio Code 🖥️
- **Linguagem**: C# 🟢, .NET 🔵, MongoDB 🍃

---

## 🚀 Execução do Projeto

### 📋 Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) 🌐
- [MongoDB](https://www.mongodb.com/) 🍃

### 📥 Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/laiscrz/movix-crud-api.git
   cd movix-crud-api
   ```

2. Configure o MongoDB e atualize `appsettings.json` com a string de conexão.

3. **Para executar a API**:
   ```bash
   cd WebApi
   dotnet run
   ```

4. **Para executar os testes**:
   ```bash
   cd Tests
   dotnet test
   ```

---

## 📄 Licença

Licenciado sob a licença MIT. Consulte o arquivo [LICENSE](https://github.com/laiscrz/movix-crud-api/blob/main/LICENSE).

---

> Este README fornece todas as informações necessárias para utilizar a Movix CRUD API de forma eficaz.
> **Aproveite sua experiência com o Movix API! 🎥**
