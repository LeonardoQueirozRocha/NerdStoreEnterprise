using NSE.Orders.API.Application.DTOs;
using NSE.Orders.API.Application.Queries.Interfaces;
using NSE.Orders.Domain.Vouchers.Interfaces;

namespace NSE.Orders.API.Application.Queries
{
    public class VoucherQueries : IVoucherQueries
    {
        private readonly IVoucherRepository _voucherRepository;

        public VoucherQueries(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        public async Task<VoucherDTO> GetVoucherByCodeAsync(string code)
        {
            var voucher = await _voucherRepository.GetVoucherbyCodeAsync(code);

            if (voucher == null) return null;

            if (!voucher.IsValidForUse()) return null;

            return new VoucherDTO
            {
                Code = code,
                DiscountType = (int)voucher.DiscountType,
                Percentage = voucher.Percentage,
                DiscountValue = voucher.DiscountValue,
            };
        }
    }
}
