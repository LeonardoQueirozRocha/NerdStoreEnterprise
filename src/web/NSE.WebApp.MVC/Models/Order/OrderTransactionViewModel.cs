using NSE.Core.Validations;
using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Models.Customer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.MVC.Models.Order
{
    public class OrderTransactionViewModel
    {
        #region Order
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }
        public string VoucherCode { get; set; }
        public bool UsedVoucher { get; set; }

        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        #endregion

        #region Address
        public AddressViewModel Address { get; set; }
        #endregion

        #region Card
        [Required(ErrorMessage = "Informe o número do cartão")]
        [Display(Name = "Número do Cartão")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Informe o nome do portador do cartão")]
        [Display(Name = "Nome do Portador")]
        public string CardName { get; set; }

        [RegularExpression(@"(0[1-9]|1[0-2])\/[0-9]{2}", ErrorMessage = "O vencimento deve estar no padrão MM/AA")]
        [CardExpiration(ErrorMessage = "Cartão Expirado")]
        [Required(ErrorMessage = "Informe o vencimento")]
        [DisplayName("Data de Vencimento MM/AA")]
        public string CardExpirationDate { get; set; }

        [Required(ErrorMessage = "Informe o código de segurança")]
        [DisplayName("Código de Segurança")]
        public string CardCvv { get; set; }
        #endregion
    }
}
