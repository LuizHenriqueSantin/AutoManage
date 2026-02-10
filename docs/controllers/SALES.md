[⬅️ Voltar ao Guia Principal](../ROTAS.md)

# 🤝 Gerenciamento de Vendas (Sales)
## POST /api/Sale/Create
Realiza o cadastro de uma nova venda no sistema.

> **Entrada (Body):**
> * **VehicleId:** Id do veículo vendido. (Guid) (obrigatório)
> * **SellerId:** Id do vendedor. (Guid) (obrigatório)
> * **OwnerId:** Id do comprador (proprietário). (Guid) (obrigatório)
> * **SaleDate:** Data em que a venda foi efetivada. (DateTime) (obrigatório)
> * **FinalPrice:** Preço final da venda. (decimal) (obrigatório)

> **Regras de negócio:**
> * Veículos previamente vinculados a um proprietário não podem ser vendidos.
> * Caso o veículo possa ser vendido, o Id do proprietário será automaticamente vinculado ao veículo ao finalizar o cadastro da venda.

## PATCH /api/Sale/Update?id={saleId}

> **Regras de negócio:**
> * Embora a rota esteja mapeada na estrutura da API, o método de edição é bloqueado para este recurso.
> * Vendas são registros históricos que geram comissões e transferências de posse. Para evitar fraudes ou inconsistências fiscais, o sistema exige que qualquer erro seja corrigido via estorno (Delete) e reemissão, garantindo que cada movimentação de estoque seja rastreável.
> * Esta rota foi criada para uma possível implementação futura caso a regra de negócio seja alterada.

## DELETE /api/Sale/Delete?id={saleId}
Deleta uma venda realizada no sistema.

> **Regras de negócio:**
> * Ao deletar uma venda, o Id do comprador (proprietário) será desvinculado do veículo que havia sido vendido.

## GET /api/Sale/GetAll
Retorna os dados base de todas as vendas cadastradas.

> **Retorno:**
> * **Id:** Id da venda no sistema. (Guid)
> * **VehicleChassis:** Chassi do veículo vendido. (string)
> * **SellerName:** Nome do vendedor. (string)
> * **SaleDate:** Data em que a venda foi realizada. (DateTime)
> * **FinalPrice:** Preço final da venda. (decimal)

## GET /api/Sale/GetBySeller?sellerId={sellerId}&year={year}&month={month}
Retorna as vendas de um vendedor, filtradas por período (mês/ano) ou referentes ao período atual.

> **Entrada (Query):**
> * **SellerId:** Id do vendedor. (Guid) (obrigatório)
> * **Year:** Ano desejado para o filtro. (int) (opcional)
> * **Month:** Mês desejado para o filtro. (int) (opcional)

> **Retorno:**
> * **Id:** Id da venda no sistema. (Guid)
> * **VehicleChassis:** Chassi do veículo vendido. (string)
> * **SellerName:** Nome do vendedor. (string)
> * **SaleDate:** Data em que a venda foi realizada. (DateTime)
> * **FinalPrice:** Preço final da venda. (decimal)

> **Regras de negócio:**
> * **Ano não informado:** O sistema filtrará pelo ano atual.
> * **Mês não informado:** O sistema filtrará pelo mês atual.
