using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Shared.DataTransferObjects.UserOrder;
using E_Commerce.Shared.DataTransferObjects.Users;

namespace E_Commerce.Service.MappingProfiles;

public class OrderProfile
    : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderEntity, OrderResponse>().ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
            .ForMember(d => d.DeliveryMethodCost, o => o.MapFrom(s => s.DeliveryMethod.Price))
            .ForMember(d => d.Total, o => o.MapFrom(s => s.DeliveryMethod.Price + s.Subtotal));

        CreateMap<OrderAddress, AddressDTO>().ReverseMap();
        CreateMap<OrderItem, OrderItemDTO>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.Product.ProductId))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Product.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.Product.PictureUrl));
    }
    //Resolver Task (im cooked)
    //Added DeliveryMethodCostResolver, DeliveryMethodNameResolver, DeliveryMethodNameAsyncResolver, DeliveryMethodCostAsyncResolver
    //idk if its working or not tbh
}
