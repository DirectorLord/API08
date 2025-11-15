using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Service.Abstraction.Common;
using E_Commerce.Shared.DataTransferObjects.UserOrder;

namespace E_Commerce.Service.Abstraction;

public interface IOrderService
{
    Task<Result<OrderResponse>> CreateAsync(OrderRequest request, string email, CancellationToken cancellationToken);
    Task<Result<OrderResponse>> GetOrderAsync(string email, Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<OrderResponse>> GetAllAsync(string email, CancellationToken cancellationToken);
    Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodAsync( CancellationToken cancellationToken);

}
