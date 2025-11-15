using AutoMapper;
using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Service.Abstraction.Common;
using E_Commerce.Shared.DataTransferObjects.UserOrder;
using System.Threading.Tasks;

namespace E_Commerce.Service.MappingProfiles.Resolvers;

public class DeliveryMethodCostAsyncResolver
{
    private readonly IUnitOfWork _unitOfWork;
    public DeliveryMethodCostAsyncResolver(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<decimal> ResolveAsync(OrderEntity source, OrderResponse destination, decimal destMember, ResolutionContext context)
    {
        if (source.DeliveryMethodId is not int id) return 0m;
        var method = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(id);
        return method?.Price ?? 0m;
    }
}