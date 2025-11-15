using AutoMapper;
using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Service.Abstraction.Common;
using E_Commerce.Shared.DataTransferObjects.UserOrder;
using System.Threading.Tasks;

namespace E_Commerce.Service.MappingProfiles.Resolvers;

public class DeliveryMethodNameAsyncResolver
{
    private readonly IUnitOfWork _unitOfWork;
    public DeliveryMethodNameAsyncResolver(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<string> ResolveAsync(OrderEntity source, OrderResponse destination, string destMember, ResolutionContext context)
    {
        if (source.DeliveryMethodId is not int id) return string.Empty;
        var method = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(id);
        return method?.ShortName ?? string.Empty;
    }
}