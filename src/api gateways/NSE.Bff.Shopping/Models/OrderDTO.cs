using NSE.Core.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSE.Bff.Shopping.Models
{
    public class OrderDTO
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
        public string VoucherCode { get; set; }
        public bool UsedVoucher { get; set; }
        public List<CartItemDTO> OrderItems { get; set; }
        #endregion

        #region Address
        public AddressDTO Address { get; set; }
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
