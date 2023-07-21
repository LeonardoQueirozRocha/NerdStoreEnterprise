using NSE.WebApp.MVC.Models.Customer;
using System.Security.Principal;

namespace NSE.WebApp.MVC.Models.Order
{
    public class OrderViewModel
    {
        #region Order
        public int Code { get; set; }
        //Authorized = 1,
        //Paid = 2,
        //Refused = 3,
        //Delivered = 4,
        //Canceled = 5
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }
        public bool UsedVoucher { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
        #endregion

        #region Order Item
        public class OrderItemViewModel
        {
            public Guid ProductId { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Value { get; set; }
            public string Image { get; set; }
        }
        #endregion

        #region Address
        public AddressViewModel Address { get; set; }
        #endregion

    }
}