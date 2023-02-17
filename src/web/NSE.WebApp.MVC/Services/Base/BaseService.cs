using NSE.WebApp.MVC.Extensions;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NSE.WebApp.MVC.Services.Base
{
    public abstract class BaseService
    {
        protected StringContent GetContent(object data)
        {
            return new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        }

        protected async Task<T> DeserializeResponseObject<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool HandleResponseErrors(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                    throw new CustomHttpResquestException(response.StatusCode);

                case HttpStatusCode.BadRequest:
                    return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
