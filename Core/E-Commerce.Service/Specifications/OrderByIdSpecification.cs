using E_Commerce.Domain.Entities.OrderEntities;

namespace E_Commerce.Service.Specifications;

internal class OrderByIdSpecification
    :BaseSpecification<OrderEntity>
{
    public OrderByIdSpecification(Guid id)
        :base(o => o.Id == id)
    {
        AddInclude(o => o.DeliveryMethod!);
        AddInclude(o => o.Items);
    }
}
