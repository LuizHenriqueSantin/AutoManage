# 👥 Gerenciamento de Vendedores (Sellers)
## POST /api/Seller/Create
Realiza o cadastro de um novo vendedor no sistema.

> **Entrada (Body):**
> * **Name:** Nome completo do vendedor. (string) (obrigatório)
> * **BaseSalary:** Salário base. (decimal) (obrigatório)

> **Regras de negócio:**
> * O salário base deve ser superior a zero.

## PATCH /api/Seller/Update?id={sellerId}
Atualiza o salário de um vendedor existente.

> **Entrada (Body):**
> * **BaseSalary:** Novo salário base. (decimal) (obrigatório)

> **Regras de negócio:**
> * O novo salário base deve ser superior ao atual.
> * Embora o DTO aceite o campo 'Name', ele é ignorado nesta rota para garantir a consistência do registro original do vendedor.

## DELETE /api/Seller/Delete?id={sellerId}
Deleta um vendedor existente do sistema.

> **Regras de negócio:**
> * O vendedor não pode ser deletado caso esteja ligado à uma venda (Sale).

## GET /api/Seller/GetAll
Retorna os dados base de todos os vendedores cadastrados.

> **Retorno:**
> * **Id:** Id do vendedor no sistema. (Guid)
> * **Name:** Nome do vendedor. (string)
> * **BaseSalary:** Salário base do vendedor. (decimal)

## GET /api/Seller/GetSellerWithTotalSalary?id={sellerId}
Retorna os dados do vendedor e o seu salário total referente ao mês atual (salário base + comissão).

> **Retorno:**
> * **Name:** Nome do vendedor. (string)
> * **BaseSalary:** Salário base do vendedor. (decimal)
> * **TotalSalary:** Salário total do vendedor. (decimal)

## PATCH /api/Seller/UpdateSellerOfTheMonth
Processamento mensal para definição de destaque.

> **Regras de negócio:**
> * **Critério de Seleção:** Maior valor bruto total vendido no mês atual.
> * **Desempate:** Em caso de valores idênticos, o critério de desempate é a **ordem alfabética**.
> * **Benefício:** O vendedor eleito recebe bonificação percentual em todas as comissões do mês subsequente.
> * **Uso Recomendado:** Execução via Job automático (ex: Hangfire ou Azure Functions) ao final de cada mês.
