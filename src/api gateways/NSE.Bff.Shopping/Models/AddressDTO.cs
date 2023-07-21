using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NSE.Bff.Shopping.Models
{
    public class AddressDTO
    {
        public string PublicArea { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neightborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
