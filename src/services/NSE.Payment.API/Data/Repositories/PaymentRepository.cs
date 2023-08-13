using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Payment.API.Models;
using NSE.Payment.API.Models.Interfaces;

namespace NSE.Payment.API.Data.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentContext _context;

    public PaymentRepository(PaymentContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public void AddPayment(Models.Payment payment)
    {
        _context.Payments.Add(payment);
    }

    public void AddTransaction(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
    }

    public async Task<Models.Payment> GetPaymentByOrderId(Guid orderId)
    {
        return await _context.Payments
            .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByOrderIdAsync(Guid orderId)
    {
        return await _context.Transactions
            .AsNoTracking()
                .Where(t => t.Payment.OrderId == orderId)
                    .ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
