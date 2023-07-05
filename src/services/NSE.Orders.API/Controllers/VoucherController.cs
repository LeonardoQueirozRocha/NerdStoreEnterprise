using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Orders.API.Application.DTOs;
using NSE.Orders.API.Application.Queries.Interfaces;
using NSE.WebApi.Core.Controllers;
using System.Net;

namespace NSE.Orders.API.Controllers
{
    [Authorize]
    [Route("vouchers")]
    public class VoucherController : MainController
    {
        private readonly IVoucherQuery _voucherQuery;

        public VoucherController(IVoucherQuery voucherQuery)
        {
            _voucherQuery = voucherQuery;
        }

        [HttpGet("{code}")]
        [ProducesResponseType(typeof(VoucherDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return NotFound();

            var voucher = await _voucherQuery.GetVoucherByCodeAsync(code);

            return voucher == null ? NotFound() : CustomResponse(voucher);
        }
    }
}
