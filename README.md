# 🎬 Movix CRUD API

**Movix** é uma API intuitiva e eficiente projetada para o gerenciamento de filmes, construída com .NET e utilizando o MongoDB como banco de dados. A Movix facilita a realização de operações de CRUD (Criar, Ler, Atualizar e Excluir) em um catálogo de filmes, permitindo que os usuários gerenciem suas coleções de maneira prática e eficaz.

## 📚 Funcionalidades

Explore as funcionalidades disponíveis na API:

| Ação                        | Descrição                                                                                     |
|-----------------------------|-----------------------------------------------------------------------------------------------|
| **➕ Adicionar Filmes**      | Adicione novos filmes ao catálogo com facilidade, incluindo todos os detalhes relevantes.     |
| **📜 Listar Filmes**        | Obtenha uma lista completa de todos os filmes no catálogo, com opções de filtro para facilitar a busca. |
| **🔍 Consultar Detalhes**   | Acesse informações detalhadas sobre um filme específico, como título, diretor, gênero, ano de lançamento e sinopse. |
| **✏️ Atualizar Filmes**     | Atualize os detalhes de filmes existentes para manter seu catálogo sempre atualizado.        |
| **❌ Excluir Filmes**       | Remova filmes do catálogo quando não forem mais necessários.                                 |

---

## 📊 Diagrama - Classe Base

A seguir, o diagrama da classe base `MovieModel`, que ilustra a estrutura dos dados de um filme na API.

```mermaid
classDiagram
    class MovieModel {
        +string Id
        +string Titulo
        +string Diretor
        +ICollection<string> Genero
        +int AnoLancamento
        +string Sinopse
    }
```

---

## 📡 Endpoints da API

### 1. **Adicionar um novo filme**

- **Método:** `POST`
- **Endpoint:** `/api/movies`
- **Corpo da Requisição:**
```json
{
  "titulo": "Nome do Filme",
  "diretor": "Nome do Diretor",
  "genero": ["Ação", "Aventura"],
  "anoLancamento": 2024,
  "sinopse": "Uma breve descrição do filme."
}
```

### 2. **Listar todos os filmes**

- **Método:** `GET`
- **Endpoint:** `/api/movies`
- **Resposta:**
```json
[
  {
    "id": "646cfe3538d5c5a77e7d4e12",
    "titulo": "Nome do Filme",
    "diretor": "Nome do Diretor",
    "genero": ["Ação", "Aventura"],
    "anoLancamento": 2024,
    "sinopse": "Uma breve descrição do filme."
  }
]
```

### 3. **Obter detalhes de um filme específico**

- **Método:** `GET`
- **Endpoint:** `/api/movies/{id}`
- **Resposta:**
```json
{
  "id": "646cfe3538d5c5a77e7d4e12",
  "titulo": "Nome do Filme",
  "diretor": "Nome do Diretor",
  "genero": ["Ação", "Aventura"],
  "anoLancamento": 2024,
  "sinopse": "Uma breve descrição do filme."
}
```

### 4. **Atualizar um filme existente**

- **Método:** `PUT`
- **Endpoint:** `/api/movies/{id}`
- **Corpo da Requisição:**
```json
{
  "titulo": "Nome Atualizado do Filme",
  "diretor": "Nome do Diretor Atualizado",
  "genero": ["Drama", "Comédia"],
  "anoLancamento": 2024,
  "sinopse": "Uma nova descrição do filme."
}
```

### 5. **Excluir um filme**

- **Método:** `DELETE`
- **Endpoint:** `/api/movies/{id}`
- **Resposta:** 
```json
{
  "message": "Filme excluído com sucesso."
}
```

---

## 🚀 Execução do Projeto

### 📋 Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/) (Recomendamos o uso do MongoDB Atlas)

### 📥 Instalação

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/laiscrz/movix-crud-api.git
   cd movix-crud-api
   ```

2. **Configure o MongoDB:**
   - Crie uma conta no MongoDB Atlas e configure um novo cluster (ou use uma instância local do MongoDB).
   - Anote sua string de conexão e o nome do banco de dados.

3. **Atualize a configuração:**
   - Modifique o arquivo `appsettings.json` com os detalhes de conexão do MongoDB.

4. **🛠️ Execute a aplicação:**
   ```bash
   dotnet run
   ```

---

## 💻 Tecnologias

Este projeto utiliza as seguintes ferramentas e tecnologias:

### 🖥️ Ambientes de Desenvolvimento Integrado (IDEs):
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)

### 📚 Linguagem de Programação:
![CSharp](https://img.shields.io/badge/CSharp-4CAF50?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-%234ea94b.svg?style=for-the-badge&logo=mongodb&logoColor=white)

---

> Este README fornece todas as informações necessárias para utilizar a Movix CRUD API de forma eficaz.
> **Aproveite sua experiência com o Movix! 🎥**
