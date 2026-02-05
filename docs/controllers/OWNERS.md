[⬅️ Voltar ao Guia Principal](../ROTAS.md)

# 🔑 Gerenciamento de Proprietários (Owners)
## POST /api/Owner/Create
Realiza o cadastro de um novo proprietário no sistema.

> **Entrada (Body):**
> * **Name:** Nome do proprietário. (string) (obrigatório)
> * **CpfCnpj:** CPF ou CNPJ do proprietário. (string) (obrigatório)
> * **Address:** Endereço do proprietário. (string) (obrigatório)
> * **Email:** Email do proprietário. (string) (obrigatório)
> * **PhoneNumber:** Telefone para contato. (string) (obrigatório)

> **Regras de negócio:**
> * O campo CpfCnpj deve conter 11 ou 14 caracteres numéricos.
> * O campo Email deve estar em um formato válido.
> * É permitido apenas 1 cadastro por CPF/CNPJ.

## PATCH /api/Owner/Update?id={ownerId}
Atualiza Email e/ou Telefone do proprietário.

> **Entrada (Body):**
> * **Email:** Novo email do proprietário. (string) (opcional)
> * **PhoneNumber:** Novo telefone. (string) (opcional)

> **Regras de negócio:**
> * Os dois campos são opcionais, porém pelo menos 1 deles deve ser informado.
> * Embora o DTO aceite os outros campos relacionados ao proprietário, eles são ignorados nesta rota para garantir a consistência do registro original.
> * O campo Email, caso enviado, deve estar em um formato válido.

## DELETE /api/Owner/Delete?id={ownerId}
Deleta um proprietário existente do sistema.

> **Regras de negócio:**
> * O proprietário não pode ser deletado caso esteja ligado à um veículo (Vehicle).

## GET /api/Owner/GetAll
Retorna os dados base de todos os proprietários cadastrados.

> **Retorno:**
> * **Id:** Id do proprietário no sistema. (Guid)
> * **Name:** Nome do proprietário. (string)
> * **CpfCnpj:** CPF/CNPJ do proprietário. (string)
> * **Address:** Endereço do proprietário. (string)
> * **Email:** Email do proprietário. (string)
> * **PhoneNumber:** Telefone de contato. (string)

## GET /api/Owner/GetByCpfCnpj?cpfCnpj={cpfCnpj}
Busca os dados de um proprietário pelo CPF ou CNPJ.

> **Retorno:**
> * **Id:** Id do proprietário no sistema. (Guid)
> * **Name:** Nome do proprietário. (string)
> * **CpfCnpj:** CPF/CNPJ do proprietário. (string)
> * **Address:** Endereço do proprietário. (string)
> * **Email:** Email do proprietário. (string)
> * **PhoneNumber:** Telefone de contato. (string)
