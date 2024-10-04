# 🎬 Movix CRUD API

> Este projeto foi submetido como parte do Checkpoint 5° Avaliativo da disciplina de Advanced Business With .NET. 📚

**Movix** é uma API intuitiva e eficiente projetada para o gerenciamento de filmes, construída com .NET e utilizando o MongoDB como banco de dados. A Movix facilita a realização de operações de CRUD (Criar, Ler, Atualizar e Excluir) em um catálogo de filmes, permitindo que os usuários gerenciem suas coleções de maneira prática e eficaz.


## 🛠️ Funcionalidades e Endpoints da API

1. **➕ Adicionar um filme**
   - **Endpoint**: `POST /api/movies`
   - **Método**: `POST`
   - **Descrição**: Adiciona um novo filme ao catálogo com todos os detalhes relevantes, como título, ano de lançamento, gênero e sinopse.

2. **📜 Listar todos os filmes**
   - **Endpoint**: `GET /api/movies`
   - **Método**: `GET`
   - **Descrição**: Retorna uma lista de todos os filmes cadastrados no catálogo, permitindo o uso de parâmetros de consulta para filtrar resultados por título, ano ou gênero.

3. **🔍 Obter detalhes de um filme**
   - **Endpoint**: `GET /api/movies/{id}`
   - **Método**: `GET`
   - **Descrição**: Acessa informações detalhadas de um filme específico pelo seu ID.

4. **✏️ Atualizar um filme**
   - **Endpoint**: `PUT /api/movies/{id}`
   - **Método**: `PUT`
   - **Descrição**: Atualiza os detalhes de um filme existente, permitindo a modificação de qualquer campo do filme.

5. **❌ Excluir um filme**
   - **Endpoint**: `DELETE /api/movies/{id}`
   - **Método**: `DELETE`
   - **Descrição**: Remove um filme do catálogo, caso não seja mais necessário.

6. **📅 Filtrar filmes por ano**
   - **Endpoint**: `GET /api/movies/year/{year}`
   - **Método**: `GET`
   - **Descrição**: Lista todos os filmes lançados em um ano específico, facilitando a busca por filmes de determinado período.

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
