using NSE.Core.DomainObjects;

namespace NSE.Customers.API.Models
{
    public class Address : Entity
    {
        public string PublicPlace { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Guid CustomerId { get; private set; }

        // EF Relation
        public Customer Customer { get; private set; }

        public Address(string publicPlace, string number, string complement, string neighborhood, string zipCode, string city, string state, Guid customerId)
        {
            PublicPlace = publicPlace;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            ZipCode = zipCode;
            City = city;
            State = state;
            CustomerId = customerId;
        }
    }
}
