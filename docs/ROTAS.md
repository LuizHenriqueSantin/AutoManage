# 📑 Guia Funcional de Rotas - AutoManage
Este guia descreve as funcionalidades de cada endpoint, os parâmetros esperados e as regras de negócio aplicadas.

## 🚦 Padrões de Resposta (Status Codes)
Para manter a consistência, todas as rotas da API seguem este padrão de retorno:

> ✅ **200 - OK:** Operação realizada com sucesso e retorno de dados.

> 🚀 **201 - Created:** Registro criado com sucesso.

> 📥 **204 - No Content:** Deleção realizada com sucesso.

> ⚠️ **400 - Bad Request:** Erro de regra de negócio ou dados inválidos. A resposta contém o motivo detalhado via Domain Notifications.

> 🚨 **500 - Internal Server Error:** Falha inesperada tratada pelo Global Exception Middleware.

---

## 📂 Módulos da API
* [**Vendedores (Sellers)**](./controllers/SELLER.md)
* [**Veículos (Vehicles)**](./controllers/VEHICLE.md)
* [**Vendas (Sales)**](./controllers/SALES.md)
* [**Proprietários (Owners)**](./controllers/OWNERS.md)
