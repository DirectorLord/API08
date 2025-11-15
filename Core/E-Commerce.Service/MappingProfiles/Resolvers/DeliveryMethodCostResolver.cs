using AutoMapper;
using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Shared.DataTransferObjects.UserOrder;

namespace E_Commerce.Service.MappingProfiles.Resolvers;

public class DeliveryMethodCostResolver : IValueResolver<OrderEntity, OrderResponse, decimal>
{
    public decimal Resolve(OrderEntity source, OrderResponse destination, decimal destMember, ResolutionContext context)
    {
        return source.DeliveryMethod?.Price ?? 0m;
    }
}