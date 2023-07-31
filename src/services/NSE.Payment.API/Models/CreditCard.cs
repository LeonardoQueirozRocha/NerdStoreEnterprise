namespace NSE.Payment.API.Models
{
    public class CreditCard
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationDate { get; set; }
        public string CardCvv { get; set; }

        protected CreditCard() { }

        public CreditCard(string cardName, string cardNumber, string cardExpirationDate, string cardCvv)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            CardExpirationDate = cardExpirationDate;
            CardCvv = cardCvv;
        }
    }
}
