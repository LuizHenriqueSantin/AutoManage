using AutoManage.Domain.Entities.Base;
using AutoManage.Domain.ValueObjects;

namespace AutoManage.Domain.Entities
{
    public class Owner : BaseEntity
    {
        public string Name { get; private set; }
        public CpfCnpj? CpfCnpj { get; private set; }
        public string Address { get; private set; }
        public Email? Email { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }

        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;
        private readonly List<Vehicle> _vehicles = new();

        protected Owner() { }

        public Owner(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void UpdateContactInfo(string? address)
        {
            if(!string.IsNullOrEmpty(address))
                Address = address;
        }

        public (bool Success, string Message) SetEmail(string? email)
        {
            if (string.IsNullOrEmpty(email))
                return (false, string.Empty);

            var result = Email.Create(email);

            if(!result.IsValid && result.Error != null)
                return (false, result.Error);

            Email = result;

            return (true, string.Empty);
        }

        public (bool Success, string Message) SetCpfCnpj(string? cpfCnpj)
        {
            if (string.IsNullOrEmpty(cpfCnpj))
                return (false, string.Empty);

            var result = CpfCnpj.Create(cpfCnpj);

            if (!result.IsValid && result.Error != null)
                return (false, result.Error);

            CpfCnpj = result;

            return (true, string.Empty);
        }

        public (bool Success, string Message) SetPhoneNumber(string? phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return (false, string.Empty);

            var result = PhoneNumber.Create(phoneNumber);

            if (!result.IsValid && result.Error != null)
                return (false, result.Error);

            PhoneNumber = result;

            return (true, string.Empty);
        }
    }
}
