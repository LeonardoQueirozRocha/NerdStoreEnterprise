using NSE.Core.Specification;
using System.Linq.Expressions;

namespace NSE.Orders.Domain.Vouchers.Specs
{
    public class VoucherDataSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression() => voucher => voucher.ValidationDate >= DateTime.Now;
    }

    public class VoucherQuantitySpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression() => voucher => voucher.Quantity > 0;
    }

    public class VoucherActiveSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression() => voucher => voucher.Active && !voucher.Used;
    }
}
