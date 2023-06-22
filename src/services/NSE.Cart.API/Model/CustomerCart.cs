namespace NSE.Cart.API.Model
{
    public class CustomerCart
    {
        internal const int MAX_ITEM_QUANTITY = 5;

        public CustomerCart() { }

        public CustomerCart(Guid customerId)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalValue { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        internal void CalculateCartValue() => TotalValue = Items.Sum(p => p.CalculateValue());

        internal bool CartItemExists(CartItem item) => Items.Any(p => p.ProductId == item.ProductId);

        internal CartItem GetByProductId(Guid productId) => Items.FirstOrDefault(p => p.ProductId == productId);

        internal void AddItem(CartItem item)
        {
            if (!item.IsValid()) return;

            item.AttachCart(Id);

            if (CartItemExists(item))
            {
                var existingItem = GetByProductId(item.ProductId);
                existingItem.AddUnits(item.Quantity);

                item = existingItem;
                Items.Remove(existingItem);
            }

            Items.Add(item);
            CalculateCartValue();
        }
    }
}
