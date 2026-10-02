# CP5 - API RESTful com .NET 10

## Controle de Tarefas

API RESTful desenvolvida em C# com .NET 10 para gerenciamento de tarefas, utilizando Entity Framework Core e banco de dados MySQL.

---

## Integrantes

- Lucas Catroppa Piratininga Dias — RM555450
- Fernando Gonzales Alexandre — RM555045
- Gabriel Guerreiro Escobosa Vallejo — RM554973
- Luiz Felipe Coelho Ramos — RM555074
- Vitor Musolino Teixeira — RM555012

---

## Contexto e Problema

O projeto tem como objetivo desenvolver uma API para controle e gerenciamento de tarefas.

A aplicação permite cadastrar, consultar, atualizar e excluir tarefas, possibilitando organizar atividades por título, descrição, data de criação, data de vencimento e status de conclusão.

A solução é voltada para usuários que precisam organizar e acompanhar suas atividades de forma simples através de uma API RESTful.

---

## Tecnologias Utilizadas

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Pomelo.EntityFrameworkCore.MySql
- Swagger
- Postman
- GitHub

---

## Banco de Dados

O projeto utiliza o **MySQL** como banco de dados.

### Banco utilizado

```text
cp5_tarefas
```

### Tabela

```text
tarefas
```

### Estrutura da tabela

| Campo | Tipo | Descrição |
|---|---|---|
| Id | int | Identificador da tarefa |
| Titulo | varchar(100) | Título da tarefa |
| Descricao | varchar(500) | Descrição da tarefa |
| DataCriacao | datetime | Data de criação |
| DataVencimento | datetime | Data de vencimento |
| Concluida | boolean | Indica se a tarefa foi concluída |

---

## Estrutura do Projeto

```text
ControleTarefas/
│
├── Controllers/
│   └── TarefasController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│   ├── 20261002220706_InitialCreate.cs
│   └── AppDbContextModelSnapshot.cs
│
├── Models/
│   └── Tarefa.cs
│
├── Postman/
│
├── .gitignore
├── appsettings.json
├── Program.cs
├── ControleTarefas.csproj
└── README.md
```

---

## Configuração do Banco de Dados

Antes de executar a aplicação, é necessário possuir o MySQL instalado e em execução.

A conexão utilizada no ambiente local deve apontar para o banco:

```text
Server=localhost;
Port=3306;
Database=cp5_tarefas;
User=root;
Password=SUA_SENHA;
```

O banco pode ser criado através do MySQL Workbench:

```sql
CREATE DATABASE cp5_tarefas;
```

---

## Executando o Projeto

### 1. Clonar o repositório

```bash
git clone URL_DO_REPOSITORIO
```

### 2. Entrar na pasta do projeto

```bash
cd ControleTarefas
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Criar/atualizar o banco através da Migration

```bash
dotnet ef database update
```

### 5. Executar a aplicação

```bash
dotnet run
```

A API poderá ser acessada através do Swagger disponibilizado pela aplicação.

---

## Entity Framework Core e Migration

O projeto utiliza o Entity Framework Core para realizar o mapeamento das entidades e operações com o banco de dados.

Foi criada uma Migration inicial chamada:

```text
InitialCreate
```

Comando utilizado para criação:

```bash
dotnet ef migrations add InitialCreate
```

Comando utilizado para aplicar a Migration ao banco:

```bash
dotnet ef database update
```

A Migration cria a estrutura necessária para a tabela `tarefas` no banco de dados `cp5_tarefas`.

### Evidência da Migration

**[INSERIR PRINT DA MIGRATION AQUI]**

---

# Endpoints

A API utiliza versionamento através da rota:

```text
/api/v1
```

## GET - Listar todas as tarefas

```http
GET /api/v1/tarefas
```

Retorna todas as tarefas cadastradas.

### Resposta esperada

```http
200 OK
```

### Evidência

**[INSERIR PRINT DO GET /api/v1/tarefas AQUI]**

---

## GET - Buscar tarefa por ID

```http
GET /api/v1/tarefas/{id}
```

Retorna uma tarefa específica através do seu identificador.

### Respostas

```http
200 OK
404 Not Found
```

### Evidência

**[INSERIR PRINT DO GET /api/v1/tarefas/{id} AQUI]**

---

## POST - Criar tarefa

```http
POST /api/v1/tarefas
```

Cria uma nova tarefa.

### Exemplo de requisição

```json
{
  "titulo": "Estudar C#",
  "descricao": "Revisar conteúdo para a prova",
  "dataVencimento": "2026-10-15T20:00:00"
}
```

A data de criação é definida automaticamente pela API e uma nova tarefa é criada como não concluída.

### Respostas

```http
201 Created
400 Bad Request
```

### Evidência

**[INSERIR PRINT DO POST /api/v1/tarefas AQUI]**

---

## PUT - Atualizar tarefa

```http
PUT /api/v1/tarefas/{id}
```

Atualiza os dados de uma tarefa existente.

### Exemplo de requisição

```json
{
  "id": 1,
  "titulo": "Estudar C# e .NET",
  "descricao": "Revisar Entity Framework Core",
  "dataVencimento": "2026-10-20T20:00:00",
  "concluida": true
}
```

### Respostas

```http
204 No Content
400 Bad Request
404 Not Found
```

### Evidência

**[INSERIR PRINT DO PUT /api/v1/tarefas/{id} AQUI]**

---

## DELETE - Excluir tarefa

```http
DELETE /api/v1/tarefas/{id}
```

Exclui uma tarefa através do seu identificador.

### Respostas

```http
204 No Content
404 Not Found
```

### Evidência

**[INSERIR PRINT DO DELETE /api/v1/tarefas/{id} AQUI]**

---

# Status HTTP Utilizados

| Status | Descrição |
|---|---|
| 200 | Requisição realizada com sucesso |
| 201 | Recurso criado com sucesso |
| 204 | Operação realizada sem conteúdo de retorno |
| 400 | Requisição inválida |
| 404 | Recurso não encontrado |

---

# Evidências dos Testes

Os endpoints foram testados utilizando o Swagger e/ou Postman.

## Swagger

**[INSERIR PRINT DO SWAGGER AQUI]**

---

## GET - Listagem

**[INSERIR PRINT AQUI]**

---

## GET - Por ID

**[INSERIR PRINT AQUI]**

---

## POST - Criação

**[INSERIR PRINT AQUI]**

---

## PUT - Atualização

**[INSERIR PRINT AQUI]**

---

## DELETE - Exclusão

**[INSERIR PRINT AQUI]**

---

## Banco de Dados

**[INSERIR PRINT DO MYSQL WORKBENCH MOSTRANDO A TABELA TAREFAS AQUI]**

---

# Considerações Finais

O projeto implementa uma API RESTful para gerenciamento de tarefas utilizando ASP.NET Core Web API, Entity Framework Core e MySQL.

A aplicação possui operações de criação, consulta, atualização e exclusão de tarefas, além de versionamento da API através da rota `/api/v1`.

O banco de dados é gerenciado através do Entity Framework Core utilizando Migrations.
