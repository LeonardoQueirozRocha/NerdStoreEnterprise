using NSE.Core.Data;

namespace NSE.Customers.API.Models.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByCpfAsync(string cpf);
        void Add(Customer customer);
        Task<Address> GetAddressByIdAsync(Guid id);
        void AddAddress(Address address);
    }
}
