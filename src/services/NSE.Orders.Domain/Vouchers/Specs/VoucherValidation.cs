using NSE.Core.Specification.Validation;

namespace NSE.Orders.Domain.Vouchers.Specs
{
    public class VoucherValidation : SpecValidator<Voucher>
    {
        public VoucherValidation()
        {
            var dateSpec = new VoucherDataSpecification();
            var quantitySpec = new VoucherQuantitySpecification();
            var activeSpec = new VoucherActiveSpecification();

            Add("dateSpec", new Rule<Voucher>(dateSpec, "Este voucher está expirado"));
            Add("quantitySpec ", new Rule<Voucher>(quantitySpec, "Este voucher já foi utilizado"));
            Add("activeSpec", new Rule<Voucher>(activeSpec, "Este voucher não está mais ativo"));
        }
    }
}
