using E_Commerce.Service.Abstraction.Common;
using E_Commerce.Shared.DataTransferObjects.UserOrder;

namespace E_Commerce.Service.Abstraction;

public interface IOrderService
{
    Task<Result<OrderResponse>> CreateAsync(OrderRequest request, string email);
}
