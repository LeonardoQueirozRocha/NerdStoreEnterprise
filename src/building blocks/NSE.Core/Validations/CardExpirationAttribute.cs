using System.ComponentModel.DataAnnotations;

namespace NSE.Core.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class CardExpirationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var month = value.ToString().Split('/')[0];
            var year = $"20{value.ToString().Split('/')[1]}";

            if (int.TryParse(month, out var parsedMonth) && int.TryParse(year, out var parsedYear))
            {
                var day = new DateTime(parsedMonth, parsedYear, 1);
                return day > DateTime.UtcNow;
            }

            return false;
        }
    }
}
