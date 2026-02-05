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
> * Embora o DTO aceito o campo 'Name', ele é ignorado nesta rota para garantir a consistência do registro original do vendedor.

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
Compara as vendas do mes de todos os vendedores e seleciona o vendedor que teve o maior valor vendido como "Vendedor do mês".

> **Entrada:**
> * Não recebe nenhum parâmetro.

> **Regras de negócio:**
> * O vendedor selecionado como vendedor do mês recebe um aumento na comissão das vendas no próximo mês.
> * Deve ser utilizado apenas no final do mês, preferencialmente em um Job executado automaticamente.
> * Em caso de empate, o vendedor será selecionado em ordem alfabética entre os vendedores empatados.
