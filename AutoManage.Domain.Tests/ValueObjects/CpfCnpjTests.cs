using AutoManage.Domain.ValueObjects;

namespace AutoManage.Domain.Tests.ValueObjects
{
    public class CpfCnpjTests
    {
        [Fact(DisplayName = "Cpf válido deve passar")]
        [Trait("Categoria", "Domínio - Value Objects")]
        public void ValidCpf()
        {
            var cpfInput = "123.456.789-01";

            var cpf = CpfCnpj.Create(cpfInput);

            Assert.True(cpf.IsValid);
        }

        [Fact(DisplayName = "Cnpj válido deve passar")]
        [Trait("Categoria", "Domínio - Value Objects")]
        public void ValidCnpj()
        {
            var cnpjInput = "12345678901234";

            var cnpj = CpfCnpj.Create(cnpjInput);

            Assert.True(cnpj.IsValid);
        }

        [Fact(DisplayName = "Cpf/Cnpj inválido não deve passar")]
        [Trait("Categoria", "Domínio - Value Objects")]
        public void InvalidCpfCnpj()
        {
            var input = "123.456.789";

            var result = CpfCnpj.Create(input);

            Assert.False(result.IsValid);
            Assert.NotNull(result.Error);
        }
    }
}
