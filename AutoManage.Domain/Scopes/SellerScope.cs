using AutoManage.Domain.Entities;

namespace AutoManage.Domain.Scopes
{
    public static class SellerScope
    {
        public static bool CanUpdateBaseSalary(this Seller seller, decimal newSalary)
        {
            return seller != null && newSalary > seller.BaseSalary;
        }
    }
}
