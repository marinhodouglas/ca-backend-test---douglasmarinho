# Projeto BillingAPI

Este projeto implementa uma API para gerenciamento de faturamento de clientes, com funcionalidades para criar, atualizar, ler e deletar informações de clientes e produtos, além de importar dados de faturamento de APIs externas.

## Tecnologias Utilizadas

- **Plataforma:** .NET Core 8.0.302
- **Linguagem:** C#
- **Banco de Dados:** SQL Server
- **Ferramentas:** Postman para testes de API, Swagger para documentação e teste de API

## Estrutura da API

A API possui os seguintes endpoints principais:

### Clientes

- **GET** `/api/customers`: Retorna todos os clientes cadastrados.
- **GET** `/api/customers/{id}`: Retorna um cliente específico pelo ID.
- **POST** `/api/customers`: Cria um novo cliente.
- **PUT** `/api/customers/{id}`: Atualiza as informações de um cliente existente.
- **DELETE** `/api/customers/{id}`: Remove um cliente pelo ID.

### Produtos

- **GET** `/api/products`: Retorna todos os produtos cadastrados.
- **GET** `/api/products/{id}`: Retorna um produto específico pelo ID.
- **POST** `/api/products`: Cria um novo produto.
- **PUT** `/api/products/{id}`: Atualiza as informações de um produto existente.
- **DELETE** `/api/products/{id}`: Remove um produto pelo ID.

### Importação de Faturamento

- **POST** `/api/import/billing`: Importa dados de faturamento de uma API externa.

## Configuração

Para executar este projeto localmente, siga estas etapas:

1. **Clonar o repositório**:

   ```bash
   git clone https://github.com/marinhodouglas/ca-backend-test---douglasmarinho
   cd BillingAPI

2. **Configurar o ambiente**:
- Instale o SDK do .NET Core 8.0 ou superior.
- Configure seu banco de dados SQL Server atualizando a connection string em `appsettings.json`.

3. **Executar a aplicação**:

    ```bash
   dotnet run
   
5. **Testar a API**:
- Use o Postman ou outra ferramenta de sua preferência para enviar requisições HTTP para os endpoints listados acima.

## Documentação da API (Swagger)

A API está documentada usando o Swagger, uma ferramenta para descrição, documentação e teste de APIs. Após iniciar a aplicação localmente, acesse a documentação da API em:

http://localhost:{porta}/swagger

Substitua `{porta}` pela porta em que a aplicação está sendo executada localmente (por padrão, é geralmente 5000 ou 5001).

## Arquitetura do Projeto

O projeto segue uma arquitetura em camadas, com separação de responsabilidades entre Controllers, Services e Repositories. Utiliza o padrão Repository para acesso aos dados e serviços para regras de negócio.

