using System.Net;
using System.Text.Json;
using System.Text;
using NSE.Core.Communication;

namespace NSE.Bff.Shopping.Services.Base
{
    public class BaseService
    {
        protected StringContent GetContent(object data) => new(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        protected async Task<T> DeserializeResponseObject<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool HandleResponseErrors(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest) return false;

            response.EnsureSuccessStatusCode();

            return true;
        }

        protected ResponseResult Ok() => new();
    }
}
