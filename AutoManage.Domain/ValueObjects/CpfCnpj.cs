using System.Text.RegularExpressions;

namespace AutoManage.Domain.ValueObjects
{
    public sealed class CpfCnpj
    {
        public string? Value { get;}
        public bool IsValid { get; }
        public string? Error { get; }

        public CpfCnpj() { }

        private CpfCnpj(string? value, bool isValid, string? error)
        {
            Value = value;
            IsValid = isValid;
            Error = error;
        }

        public static CpfCnpj Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new CpfCnpj(null, false, "CPF/CNPJ é obrigatório!");

            var numeric = Regex.Replace(input, @"\D", "");

            if (numeric.Length != 11 && numeric.Length != 14)
                return new CpfCnpj(null, false, "CPF/CNPJ deve conter 11 ou 14 dígitos!");

            return new CpfCnpj(numeric, true, null);
        }

        public override string ToString() => Value ?? string.Empty;
    }
}
