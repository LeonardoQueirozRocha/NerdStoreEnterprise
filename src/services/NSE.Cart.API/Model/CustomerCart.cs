namespace NSE.Cart.API.Model
{
    public class CustomerCart
    {
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
    }
}
