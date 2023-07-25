using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.MVC.Models.Customer
{
    public class AddressViewModel
    {
        [Required]
        [DisplayName("Logradouro")]
        public string PublicPlace { get; set; }

        [Required]
        [DisplayName("Número")]
        public string Number { get; set; }

        [DisplayName("Complemento")]
        public string Complement { get; set; }

        [Required]
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }

        [Required]
        [DisplayName("CEP")]
        public string ZipCode { get; set; }

        [Required]
        [DisplayName("Cidade")]
        public string City { get; set; }

        [Required]
        [DisplayName("Estado")]
        public string State { get; set; }

        public override string ToString()
        {
            return $"{PublicPlace}, {Number} {Complement} - {Neighborhood} - {City} - {State}";
        }
    }
}
