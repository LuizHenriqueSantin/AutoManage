# AutoManage API
Sistema de gestão de concessionária desenvolvido com ASP.NET Core 8, focado em alta performance, resiliência e código limpo.

## 🛠️ Arquitetura e Tecnologias
O projeto foi construído seguindo os princípios do Domain-Driven Design (DDD) e Clean Architecture, garantindo a separação de responsabilidades e facilidade de manutenção.

> **Linguagem:** .NET 8

> **Banco de Dados:** SQL Server (com Entity Framework Core)

> **Design Patterns:** Repository Pattern, Unit of Work, Domain Notifications e Middleware.

> **Documentação:** Swagger e Guia Funcional de Rotas.

> **Logging:** ILogger estruturado com foco em observabilidade.

## 🛡️ Diferenciais Técnicos
### Global Exception Middleware
Implementei um Middleware de Exceção Global que atua como uma rede de segurança para a aplicação.

> **Resiliência:** Captura erros de infraestrutura (banco, rede, runtime) automaticamente.

> **Segurança:** Impede que detalhes técnicos (stack trace) sejam expostos ao usuário final.

> **Observabilidade:** Loga automaticamente o Método HTTP, a Rota e a QueryString, permitindo rastreio imediato de falhas no console.

### Domain Notifications vs Exceptions
Diferenciei erros de "infraestrutura" de erros de "regra de negócio":

> **Exceptions:** Tratadas pelo Middleware (Erros inesperados / Status 500).

> **Domain Notifications:** Tratadas por um Action Filter, retornando mensagens de validação amigáveis (Status 400 - BadRequest) sem interromper o fluxo com exceções pesadas.

## 🏛️ Detalhes da Arquitetura
O projeto utiliza uma divisão clara em camadas para garantir que a Lógica de Domínio seja independente de frameworks externos:

> **Domain:** O coração do sistema. Contém as Entidades, Value Objects, Interfaces e as Regras de Negócio. É uma camada pura (sem dependências de banco de dados).

> **Application:** Onde residem as Queries e Commands. Gerencia o fluxo de dados e a orquestração das ações do usuário.

> **Infrastructure:** Implementação técnica. Contém o DbContext, Repositórios e configurações do Entity Framework.

> **API:** A porta de entrada. Gerencia as rotas, Injeção de Dependência e Middlewares.
<img width="500" alt="image" src="https://github.com/user-attachments/assets/94195d56-c6bc-4073-ad82-3890ee666a98" />



## 💎 Value Objects
Em vez de usar apenas tipos primitivos, utilizei Value Objects para garantir a integridade dos dados:

> **Exemplo:** Cpf, Email ou Telefone. Um VO não possui identidade própria, ele é definido pelo seu valor e possui validação interna, impedindo que um objeto inválido entre no sistema.

## ⚡ CQRS Simplificado (Commands & Queries)
Para manter o princípio da Responsabilidade Única, separei as intenções de escrita e leitura:

> **Commands:** Encapsulam ações que alteram o estado do sistema.

> **Queries:** Focadas em recuperar dados de forma performática para a interface.

## 💉 Injeção de Dependência e Inversão de Controle (IoC)
O projeto faz uso extensivo de Injeção de Dependência nativa do .NET para desacoplar as classes:

> **Benefício:** Facilita a manutenção e permite que as classes dependam de Abstrações (Interfaces) e não de implementações concretas (Inversão de Controle).

> **Centralização:** Toda a configuração de IoC está isolada na camada de CrossCutting, mantendo o Program.cs limpo e organizado.

## 🛠️ Configuração de Banco de Dados (EF Core)
> **Migrations:** O histórico de evolução do banco é mantido via migrations.

> **Fluent API:** As configurações de tabelas e relacionamentos não "poluem" as classes de domínio, ficando isoladas na camada de Infra.Data.Mapping.
<img width="500" alt="image" src="https://github.com/user-attachments/assets/9cee7ef1-a290-4572-8a4b-70d804330367" />



## 📖 Documentação de Referência
Para facilitar o entendimento das regras de negócio e integração, a documentação está dividida em duas partes:

> **Swagger:** Disponível em tempo de execução na rota /swagger. Ideal para testar os endpoints e visualizar os schemas JSON.

> **Guia Funcional de Rotas:** [Clique aqui para acessar o detalhamento das rotas](./docs/ROTAS.md).
