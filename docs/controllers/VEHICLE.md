[⬅️ Voltar ao Guia Principal](../ROTAS.md)

# 🚗 Gerenciamento de Veículos (Vehicles)
## POST /api/Vehicle/Create
Realiza o cadastro de um novo veículo no sistema.

> **Entrada (Body):**
> * **Chassis:** Chassi do veículo. (string) (obrigatório)
> * **Model:** Modelo do veiculo. (string) (obrigatório)
> * **Year:** Ano de fabricação. (int) (obrigatório)
> * **Color:** Cor do veículo (Enum: `1=Preto`, `2=Branco`, `3=Prata`, `4=Azul`, `5=Vermelho`) (obrigatório)
> * **Price:** Preço do veículo (decimal) (obrigatório)
> * **Mileage:** Quilometragem do veículo (int) (obrigatório)
> * **SystemVersion:** Versão do sistema (Enum: `1=Básico`, `2=Intermediário`, `3=Completo`) (obrigatório)

## PATCH /api/Vehicle/Update?id={vehicleId}
Atualiza a quilometragem e/ou o preço do veículo.

> **Entrada (Body):**
> * **Price:** Novo preço. (decimal) (opcional)
> * **Mileage:** Nova quilometragem (int) (opcional)

> **Regras de negócio:**
> * Os dois campos são opcionais, porém pelo menos 1 deles deve ser informado.
> * Embora o DTO aceite os outros campos relacionados ao veículo, eles são ignorados nesta rota para garantir a consistência do registro original do veículo.

## DELETE /api/Vehicle/Delete?id={vehicleId}
Deleta um veículo existente do sistema.

> **Regras de negócio:**
> * O veículo não pode ser deletado caso esteja ligado à uma venda (Sale).

## GET /api/Vehicle/GetAll
Retorna os dados base de todos os veículos cadastrados.

> **Retorno:**
> * **Id:** Id do veículo no sistema. (Guid)
> * **Chassis:** Chassi do veículo. (string)
> * **Model:** Modelo do veículo. (string)
> * **Year:** Ano de fabricação. (int)
> * **Color:** Enum da cor do veículo (Enum: `1=Preto`, `2=Branco`, `3=Prata`, `4=Azul`, `5=Vermelho`)
> * **ColorName:** Cor do veículo (string)
> * **Price:** Preço do veículo (decimal)
> * **Mileage:** Quilometragem do veículo (int)
> * **SystemVersion:** Enum da versão do sistema (Enum: `1=Básico`, `2=Intermediário`, `3=Completo`)
> * **SystemVersionName:** Versão do sistema (string)

## PATCH /api/Vehicle/UpdateByChassis
Localiza um veículo pelo Chassi e atualiza seus dados comerciais.

> **Entrada (Body):**
> * **Chassis:** Chassi do veículo. (string) (obrigatório)
> * **Price:** Novo preço. (decimal) (opcional)
> * **Mileage:** Nova quilometragem (int) (opcional)

> **Regras de negócio:**
> * 'Price' e 'Mileage' são opcionais, porém pelo menos 1 deles deve ser informado.
> * Embora o DTO aceite os outros campos relacionados ao veículo, eles são ignorados nesta rota para garantir a consistência do registro original do veículo.

## GET /api/Vehicle/GetBySystemVersion?version={systemVersion}
Filtra a listagem de veículos com base no nível de tecnologia embarcada.

> **Entrada (Query):**
> * **version:** Versão do sistema (Enum: `1=Básico`, `2=Intermediário`, `3=Completo`) (obrigatório)

> **Retorno:**
> * **Chassis:** Chassi do veículo. (string)
> * **Model:** Modelo do veículo. (string)
> * **Year:** Ano de fabricação. (int)
> * **Color:** Enum da cor do veículo (Enum: `1=Preto`, `2=Branco`, `3=Prata`, `4=Azul`, `5=Vermelho`)
> * **ColorName:** Cor do veículo (string)
> * **Price:** Preço do veículo (decimal)
> * **Mileage:** Quilometragem do veículo (int)
> * **SystemVersion:** Enum da versão do sistema (Enum: `1=Básico`, `2=Intermediário`, `3=Completo`)
> * **SystemVersionName:** Versão do sistema (string)

## GET /api/Vehicle/GetWithOwner?id={vehicleId}
Retorna os dados do veículo e do proprietário (se existir).

> **Retorno:**
> * **Chassis:** Chassi do veículo. (string)
> * **Model:** Modelo do veículo. (string)
> * **Year:** Ano de fabricação. (int)
> * **Color:** Enum da cor do veículo (Enum: `1=Preto`, `2=Branco`, `3=Prata`, `4=Azul`, `5=Vermelho`)
> * **ColorName:** Cor do veículo (string)
> * **Price:** Preço do veículo (decimal)
> * **Mileage:** Quilometragem do veículo (int)
> * **SystemVersion:** Enum da versão do sistema (Enum: `1=Básico`, `2=Intermediário`, `3=Completo`)
> * **SystemVersionName:** Versão do sistema (string)
> * **Owner:**
>   * **Name:** Nome do proprietário.
>   * **CpfCnpj:** Cpf/Cnpj do proprietário.
>   * **Address:** Endereço do proprietário.
>   * **Email:** Email do proprietário.
>   * **PhoneNumber:** Telefone do proprietário.

> **Regras de negócio:**
> * Se o veículo não tiver proprietário o objeto Owner retornará 'null'.
