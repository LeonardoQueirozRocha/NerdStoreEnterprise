using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using NSE.Orders.API.Application.DTOs;
using NSE.Orders.API.Application.Events;
using NSE.Orders.Domain.Orders;
using NSE.Orders.Domain.Orders.Interfaces;
using NSE.Orders.Domain.Vouchers.Interfaces;
using NSE.Orders.Domain.Vouchers.Specs;

namespace NSE.Orders.API.Application.Commands
{
    public class OrderCommandHandler : CommandHandler, IRequestHandler<AddOrderCommand, ValidationResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IVoucherRepository _voucherRepository;

        public OrderCommandHandler(
            IOrderRepository orderRepository,
            IVoucherRepository voucherRepository)
        {
            _orderRepository = orderRepository;
            _voucherRepository = voucherRepository;
        }

        public async Task<ValidationResult> Handle(AddOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var order = OrderMap(message);

            if (await CanOrderBeProcessedAsync(message, order)) return ValidationResult;

            order.AuthorizeOrder();

            order.AddEvent(new AccomplishedOrderEvent(order.Id, order.CustomerId));

            _orderRepository.Add(order);

            return await PersistDataAsync(_orderRepository.UnitOfWork);
        }

        private static Order OrderMap(AddOrderCommand message)
        {
            var address = new Address
            {
                PublicPlace = message.Address.PublicPlace,
                Number = message.Address.Number,
                Complement = message.Address.Complement,
                Neighborhood = message.Address.Neighborhood,
                ZipCode = message.Address.ZipCode,
                City = message.Address.City,
                State = message.Address.State
            };

            var order = new Order(
                message.CustomerId,
                message.TotalValue,
                message.OrderItems.Select(OrderItemDTO.ForOrderItem).ToList(),
                message.UsedVoucher,
                message.Discount);

            order.AssignAddress(address);

            return order;
        }

        private async Task<bool> ApplyVoucherAsync(AddOrderCommand message, Order order)
        {
            if (!message.UsedVoucher) return true;

            var voucher = await _voucherRepository.GetVoucherbyCodeAsync(message.VoucherCode);

            if (voucher == null)
            {
                AddError("O voucher informado não existe!");
                return false;
            }

            var voucherValidation = new VoucherValidation().Validate(voucher);
            if (!voucherValidation.IsValid)
            {
                voucherValidation.Errors.ForEach(error => AddError(error.ErrorMessage));
                return false;
            }

            order.AssignVoucher(voucher);
            voucher.DebitQuantity();

            _voucherRepository.Update(voucher);

            return true;
        }

        private bool ValidateOrder(Order order)
        {
            var originalOrderValue = order.TotalValue;
            var orderDiscount = order.Discount;

            order.CalculateOrderValue();

            if (order.TotalValue != originalOrderValue)
            {
                AddError("O valor total do pedido não confere com o cálculo do pedido");
                return false;
            }

            if (order.Discount != orderDiscount)
            {
                AddError("O valor total não confere com o cálculo do pedido");
                return false;
            }

            return true;
        }

        public bool ProcessPayment(Order order)
        {
            return true;
        }

        private async Task<bool> CanOrderBeProcessedAsync(AddOrderCommand message, Order order)
        {
            return !await ApplyVoucherAsync(message, order) || !ValidateOrder(order) || !ProcessPayment(order);
        }
    }
}
