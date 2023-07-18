using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Customers.API.Models;
using NSE.Customers.API.Models.Interfaces;

namespace NSE.Customers.API.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public Task<Customer> GetByCpfAsync(string cpf)
        {
            return _context.Customers.FirstOrDefaultAsync(c => c.Cpf.Number == cpf);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public async Task<Address> GetAddressByIdAsync(Guid id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(e => e.CustomerId == id);
        }

        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
