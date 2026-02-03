namespace AutoManage.Application.DTOs.Owner
{
    public class OwnerOut
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CpfCnpj { get;set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
