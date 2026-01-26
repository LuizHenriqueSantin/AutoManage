using System.Text.RegularExpressions;

namespace AutoManage.Domain.ValueObjects;

public sealed class PhoneNumber
{
    public string? Value { get; }
    public bool IsValid { get; }
    public string? Error { get; }

    public PhoneNumber() { }

    private PhoneNumber(string? value, bool isValid, string? error)
    {
        Value = value;
        IsValid = isValid;
        Error = error;
    }

    public static PhoneNumber Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return new PhoneNumber(null, false, "Phone number is required");

        var numeric = Regex.Replace(input, @"\D", "");

        if (numeric.Length < 10 || numeric.Length > 13)
            return new PhoneNumber(null, false, "Invalid phone number");

        return new PhoneNumber(numeric, true, null);
    }

    public override string ToString() => Value ?? string.Empty;
}
