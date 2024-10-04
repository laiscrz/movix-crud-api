# 🎬 Movix CRUD API

> Este projeto foi submetido como parte do Checkpoint 5° Avaliativo da disciplina de Advanced Business With .NET. 📚

**Movix** é uma API intuitiva e eficiente projetada para o gerenciamento de filmes, construída com .NET e utilizando o MongoDB como banco de dados. A Movix facilita a realização de operações de CRUD (Criar, Ler, Atualizar e Excluir) em um catálogo de filmes, permitindo que os usuários gerenciem suas coleções de maneira prática e eficaz.


## 🛠️ Funcionalidades e Endpoints da API

Explore os principais endpoints da API para gerenciar seu catálogo de filmes:

| Função                                    | Endpoint                     | Método | Descrição                                                                                     |
|-------------------------------------------|------------------------------|--------|-----------------------------------------------------------------------------------------------|
| ➕ **Adicionar um Filme**                  | `POST /api/movies`          | POST   | Adiciona um novo filme ao catálogo.   |
| 📜 **Listar Todos os Filmes**             | `GET /api/movies`           | GET    | Retorna uma lista de todos os filmes cadastrados no catálogo.   |
| 🔍 **Obter Detalhes de Filme**            | `GET /api/movies/{id}`      | GET    | Acessa informações detalhadas de um filme específico pelo seu ID, permitindo ver todos os atributos do filme.                            |
| 📅 **Filtrar Filmes por Ano**             | `GET /api/movies/year/{year}` | GET    | Lista todos os filmes lançados em um ano específico.       |
| ✏️ **Atualizar um Filme**                  | `PUT /api/movies/{id}`      | PUT    | Atualiza os detalhes de um filme existente.      |
| ❌ **Excluir um Filme**                    | `DELETE /api/movies/{id}`   | DELETE | Remove um filme do catálogo.        |


> [!IMPORTANT] 
> **💡 Dica:** Exemplos dos endpoints estão disponíveis no arquivo [WebApi.http](https://github.com/laiscrz/movix-crud-api/blob/main/WebApi/WebApi.http).

---

## 📂 Estrutura do Projeto

### 📦 DTOs
- **`MovieRequestDTO.cs`**: Recebe informações nas requisições.
- **`MovieResponseDTO.cs`**: Envia informações nas respostas.

### 🗄️ Data
- **`IMongoDbSettings.cs`**: Interface para configurações do MongoDB.
- **`MongoDBFactory.cs`**: Cria a conexão com o MongoDB.
- **`MongoDbSettings.cs`**: Configurações de acesso ao MongoDB.

### 🗺️ Mapping
- **`MovieMappingProfile.cs`**: Mapeia entre os DTOs e o modelo de domínio.

### 🎬 Models
- **`IMovieModel.cs`**: Define a estrutura do modelo de filme.
- **`MovieModel.cs`**: Implementa a interface e representa um filme.

### 🏛️ Repositories
- **`IMovieRepository.cs`**: Define operações de acesso a dados para filmes.
- **`IRepository.cs`**: Interface genérica para operações de repositório.
- **`MovieRepository.cs`**: Lógica de acesso ao banco de dados para filmes.
- **`Repository.cs`**: Implementação da interface genérica para operações de repositório.

### 🧪 Tests
- **Integration**:
  - **`MoviesControllerIntegrationTests.cs`**: Testes de integração do controlador.
  - **`MovieRepositoryIntegrationTests.cs`**: Testes de integração do repositório.
- **Unit**:
  - **`MovieMappingProfileUnitTests.cs`**: Testes unitários do perfil de mapeamento.
  - **`MovieModelUnitTests.cs`**: Testes unitários do modelo de filme.

### ⚙️ WebApi
- **`IMovieController.cs`**: Interface para operações de CRUD.
- **`MovieController.cs`**: Controlador de operações de CRUD.

> **`appsettings.json`**: Configurações gerais, incluindo a string de conexão do MongoDB.


---

## Testes 🧪

A API Movix CRUD inclui duas categorias principais de testes para garantir a qualidade e a funcionalidade do código:

### 🧪 Testes Unitários

- **MovieModelUnitTests**: Realiza testes unitários para a classe `MovieModel`, garantindo que a lógica de validação e criação de instâncias funcione corretamente.

- **MovieMappingProfileUnitTests**: Testa o perfil de mapeamento do AutoMapper, assegurando que a conversão entre os DTOs e o modelo de domínio ocorra conforme o esperado.

### 🔗 Testes de Integração

- **MoviesControllerIntegrationTests**: Verifica a funcionalidade do controlador de filmes, assegurando que as operações CRUD sejam executadas corretamente.

- **MovieRepositoryIntegrationTests**: Testa o repositório de filmes, validando as operações de acesso a dados no MongoDB.

> [!WARNING]  
> **Atenção:** Os testes são executados utilizando o framework xUnit, garantindo que todas as funcionalidades sejam testadas de forma abrangente.

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
