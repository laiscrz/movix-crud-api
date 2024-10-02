# 🎬 Movix CRUD API

**Movix** é uma API intuitiva para gerenciamento de filmes, construída com .NET e MongoDB, permitindo operações de CRUD (Criar, Ler, Atualizar e Excluir) em um catálogo de filmes.

## 📚 Funcionalidades

| Ação                        | Descrição                                                                                     |
|-----------------------------|-----------------------------------------------------------------------------------------------|
| **➕ Adicionar Filmes**      | Adicione novos filmes com todos os detalhes relevantes.                                       |
| **📜 Listar Filmes**        | Obtenha uma lista completa de filmes, com opções de filtro.                                   |
| **🔍 Consultar Detalhes**   | Acesse informações detalhadas de um filme específico.                                         |
| **✏️ Atualizar Filmes**     | Atualize detalhes de filmes existentes.                                                       |
| **❌ Excluir Filmes**       | Remova filmes do catálogo quando não forem mais necessários.                                  |
| **📅 Filtrar por Ano**      | Liste filmes lançados em um ano específico.                                                  |

---

## 🏗️ Estrutura de Pastas do Projeto

```
movix-crud-api/
├── DTOs/
├── Data/
├── Models/
├── Repositories/
├── Tests/
└── WebApi/
```

### Motivos da Arquitetura 🔧
A estrutura do projeto foi projetada com base em princípios de modularidade e manutenibilidade, permitindo um desenvolvimento ágil e organizado. Aqui estão as razões para a escolha de cada componente:

| Componente       | Descrição                                                                                     |
|------------------|-----------------------------------------------------------------------------------------------|
| **DTOs**         | Define a estrutura dos dados utilizados para a transferência entre a API e o cliente, garantindo que as informações sejam transmitidas de forma clara e consistente. 📊 |
| **Data**         | Gerencia a interação com o MongoDB, possibilitando uma configuração modular e reutilizável para acessar e manipular os dados. 🗄️ |
| **Models**       | Contém as classes que representam a estrutura dos dados de domínio, refletindo a lógica de negócio da aplicação. 📁 |
| **Repositories** | Proporciona uma abstração sobre o acesso a dados, permitindo que a lógica de negócios e a persistência sejam separadas, o que facilita a testabilidade e manutenção. 🔒 |
| **Tests**        | Organiza os testes automatizados, assegurando que cada parte do código funcione como esperado e mantenha a qualidade ao longo do desenvolvimento. 🧪 |
| **WebApi**       | Centraliza a lógica da API, incluindo controladores e configuração, facilitando a implementação e o gerenciamento das rotas da aplicação. ⚙️ |
---

## 📡 Endpoints da API

1. **➕ Adicionar um filme**
   - `POST /api/movies`
2. **📜 Listar todos os filmes**
   - `GET /api/movies`
3. **🔍 Obter detalhes de um filme**
   - `GET /api/movies/{id}`
4. **✏️ Atualizar um filme**
   - `PUT /api/movies/{id}`
5. **❌ Excluir um filme**
   - `DELETE /api/movies/{id}`
6. **📅 Filtrar filmes por ano**
   - `GET /api/movies/year/{year}`

> [!IMPORTANT] 
> **💡 Dica:** Exemplos dos endpoints estão disponíveis no arquivo [WebApi.http](https://github.com/laiscrz/movix-crud-api/blob/main/WebApi/WebApi.http).

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

Se precisar de mais alguma alteração ou adição, é só avisar!
---

## 📄 Licença

Licenciado sob a licença MIT. Consulte o arquivo [LICENSE](https://github.com/laiscrz/movix-crud-api/blob/main/LICENSE).

---

> Este README fornece todas as informações necessárias para utilizar a Movix CRUD API de forma eficaz.
> **Aproveite sua experiência com o Movix API! 🎥**

