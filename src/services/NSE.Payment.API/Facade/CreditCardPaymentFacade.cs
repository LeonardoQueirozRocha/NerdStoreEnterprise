﻿using Microsoft.Extensions.Options;
using NSE.Payment.API.Facade.Interfaces;
using NSE.Payments.NerdsPay;

namespace NSE.Payment.API.Facade;

public class CreditCardPaymentFacade : IPaymentFacade
{
    private readonly PaymentConfiguration _paymentConfiguration;

    public CreditCardPaymentFacade(IOptions<PaymentConfiguration> paymentConfiguration)
    {
        _paymentConfiguration = paymentConfiguration.Value;
    }

    public async Task<Models.Transaction> AuthorizePaymentAsync(Models.Payment payment)
    {
        var nerdsPagService = new NerdsPagService(
            _paymentConfiguration.DefaultApiKey,
            _paymentConfiguration.DefaultEncryptionKey);

        var cardHashGen = new CardHash(nerdsPagService)
        {
            CardNumber = payment.CreditCard.CardNumber,
            CardHolderName = payment.CreditCard.CardName,
            CardExpirationDate = payment.CreditCard.CardExpirationDate,
            CardCvv = payment.CreditCard.CardCvv
        };

        var cardHash = cardHashGen.Generate();

        var transaction = new Transaction(nerdsPagService)
        {
            CardHash = cardHash,
            CardNumber = payment.CreditCard.CardNumber,
            CardHolderName = payment.CreditCard.CardName,
            CardExpirationDate = payment.CreditCard.CardExpirationDate,
            CardCvv = payment.CreditCard.CardCvv,
            PaymentMethod = PaymentMethod.CreditCard,
            Amount = payment.Value
        };

        return ForModelTransaction(await transaction.AuthorizeCardTransaction());
    }

    public async Task<Models.Transaction> CapturePaymentAsync(Models.Transaction transaction)
    {
        var nerdsPagSvc = new NerdsPagService(_paymentConfiguration.DefaultApiKey, _paymentConfiguration.DefaultEncryptionKey);
        var nerdPagTransaction = ForNerdPagTransaction(transaction, nerdsPagSvc);
        return ForModelTransaction(await nerdPagTransaction.CaptureCardTransaction());
    }

    public async Task<Models.Transaction> CancelAuthorizationAsync(Models.Transaction transaction)
    {
        var nerdsPagSvc = new NerdsPagService(_paymentConfiguration.DefaultApiKey, _paymentConfiguration.DefaultEncryptionKey);
        var nerdPagTransaction = ForNerdPagTransaction(transaction, nerdsPagSvc);
        return ForModelTransaction(await nerdPagTransaction.CancelAuthorization());
    }

    private static Models.Transaction ForModelTransaction(Transaction transaction)
    {
        return new Models.Transaction
        {
            Id = Guid.NewGuid(),
            TransactionStatus = (Models.Enums.TransactionStatus)transaction.Status,
            TotalValue = transaction.Amount,
            CardBrand = transaction.CardBrand,
            AuthorizationCode = transaction.AuthorizationCode,
            TransactionCost = transaction.Cost,
            TransactionDate = transaction.TransactionDate,
            NSU = transaction.Nsu,
            TID = transaction.Tid
        };
    }

    private static Transaction ForNerdPagTransaction(Models.Transaction transaction, NerdsPagService nerdsPagService)
    {
        return new Transaction(nerdsPagService)
        {
            Status = (TransactionStatus)transaction.TransactionStatus,
            Amount = transaction.TotalValue,
            CardBrand = transaction.CardBrand,
            AuthorizationCode = transaction.AuthorizationCode,
            Cost = transaction.TransactionCost,
            Nsu = transaction.NSU,
            Tid = transaction.TID
        };
    }
}

