using NSE.Core.DomainObjects;

namespace NSE.Catalog.API.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Value { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Image { get; set; }
        public int QuantityInStock { get; set; }

        public void RemoveOfStock(int quantity)
        {
            if (QuantityInStock >= quantity) 
                QuantityInStock -= quantity;
        }

        public bool IsAvailable(int quantity)
        {
            return Active && QuantityInStock >= quantity;
        }
    }
}
