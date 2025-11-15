using AutoMapper;
using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Shared.DataTransferObjects.UserOrder;

namespace E_Commerce.Service.MappingProfiles.Resolvers;

public class DeliveryMethodNameResolver : IValueResolver<OrderEntity, OrderResponse, string>
{
    public string Resolve(OrderEntity source, OrderResponse destination, string destMember, ResolutionContext context)
    {
        return source.DeliveryMethod?.ShortName ?? string.Empty;
    }
}