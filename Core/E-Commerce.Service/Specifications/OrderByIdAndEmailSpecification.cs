using E_Commerce.Domain.Entities.OrderEntities;

namespace E_Commerce.Service.Specifications;

internal class OrderByIdAndEmailSpecification
    :BaseSpecification<OrderEntity>
{
    public OrderByIdAndEmailSpecification(string email, Guid id)
        :base(o => o.Id == id && o.UserEmail == email)
    {
        AddInclude(o => o.DeliveryMethod!);
        AddInclude(o => o.Items);
    }
}
