namespace AutoManage.Application.DTOs.Seller
{
    public class SellerOut
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? BaseSalary { get; set; }
        public decimal? TotalSalary { get; set; }
    }
}
