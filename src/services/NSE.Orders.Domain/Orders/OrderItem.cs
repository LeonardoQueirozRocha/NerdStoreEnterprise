using NSE.Core.DomainObjects;

namespace NSE.Orders.Domain.Orders
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitValue { get; private set; }
        public string ProductImage { get; set; }

        public Order Order { get; set; }

        protected OrderItem() { }

        public OrderItem(
            Guid productId,
            string productName,
            int quantity,
            decimal unitValue,
            string productImage = null)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitValue = unitValue;
            ProductImage = productImage;
        }

        internal decimal CalculateValue() => Quantity * UnitValue;
    }
}
