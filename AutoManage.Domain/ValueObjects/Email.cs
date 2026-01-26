using System.Text.RegularExpressions;

namespace AutoManage.Domain.ValueObjects
{
    public sealed class Email
    {
        public string? Value { get; }
        public bool IsValid { get; }
        public string? Error { get; }

        public Email() { }

        private Email(string? value, bool isValid, string? error)
        {
            Value = value;
            IsValid = isValid;
            Error = error;
        }

        public static Email Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new Email(null, false, "Email é obrigatório!");

            if (!Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return new Email(null, false, "Email em formato inválido!");

            return new Email(input.Trim().ToLower(), true, null);
        }

        public override string ToString() => Value ?? string.Empty;
    }
}
