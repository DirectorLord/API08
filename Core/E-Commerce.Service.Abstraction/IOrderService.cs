using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Service.Abstraction.Common;
using E_Commerce.Shared.DataTransferObjects.UserOrder;

namespace E_Commerce.Service.Abstraction;

public interface IOrderService
{
    Task<Result<OrderResponse>> CreateAsync(OrderRequest request, string email);
    Task<Result<OrderResponse>> GetByIdAsync(Guid id);
    Task<IEnumerable<OrderResponse>> GetByUserEmailAsync(string email);
    Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodAsync();

}
