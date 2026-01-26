using AutoManage.Domain.Entities.Base;
using AutoManage.Domain.Scopes;

namespace AutoManage.Domain.Entities
{
    public class Seller : BaseEntity
    {
        public string Name { get; private set; }
        public decimal BaseSalary { get; private set; }
        public bool IsSellerOfTheMonth {  get; private set; }

        public IReadOnlyCollection<Sale> Sales => _sales;
        private readonly List<Sale> _sales = new();

        protected Seller() { }

        public Seller(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
            IsSellerOfTheMonth = false;
        }

        public void PromoteToSellerOfTheMonth()
        {
            IsSellerOfTheMonth = true;
        }

        public void RemoveSellerOfTheMonth()
        {
            IsSellerOfTheMonth = false;
        }

        public bool UpdateBaseSalary(decimal newSalary)
        {
            if (!this.CanUpdateBaseSalary(newSalary))
            {
                return false;
            }

            BaseSalary = newSalary;
            return true;
        }
    }
}
