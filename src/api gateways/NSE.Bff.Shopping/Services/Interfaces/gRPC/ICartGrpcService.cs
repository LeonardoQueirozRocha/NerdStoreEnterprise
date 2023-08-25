using NSE.Bff.Shopping.Models;

namespace NSE.Bff.Shopping.Services.Interfaces.gRPC;

public interface ICartGrpcService
{
    Task<CartDTO> GetCartAsync();
}