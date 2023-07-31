namespace NSE.Payment.API.Models.Enums
{
    public enum TransactionStatus
    {
        Authorized = 1,
        Paid,
        Refused,
        Chargedback,
        Cancelled
    }
}
