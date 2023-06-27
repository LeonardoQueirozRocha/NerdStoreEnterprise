using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Cryptography;
using System.Text;

namespace NSE.WebApp.MVC.Extensions
{
    public static class RazorHelpers
    {
        public static string HashEmailForGravatar(this RazorPage page, string email)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));
            var sBuilder = new StringBuilder();

            foreach (var t in data)
                sBuilder.Append(t.ToString("x2"));

            return sBuilder.ToString();
        }

        public static string FormatCurrency(this RazorPage page, decimal currency)
        {
            return currency > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", currency) : "Gratuito";
        }

        public static string StockMessage(this RazorPage page, int quantity)
        {
            return quantity > 0 ? $"Apenas {quantity} em estoque!" : "Produto esgotado!";
        }

        public static string UnityPerProduct(this RazorPage page, int unity)
        {
            return unity > 1 ? $"{unity} unidades" : $"{unity} unidade";
        }

        public static string SelectOptionsPerQuantity(this RazorPage page, int quantity, int selectedValue = 0)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < quantity; i++)
            {
                var selected = "";
                if (i == selectedValue) selected = "selected";
                sb.Append($"<option {selected} value='{i}'>{i}</option>");
            }

            return sb.ToString();
        }
    }
}
