using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Description { get; set; } //Customer can explain in description
        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }

        public Customer Customer { get; set; }
    }
}
