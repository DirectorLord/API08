using E_Commerce.Domain.Entities.OrderEntities;

namespace E_Commerce.Service.Specifications;

public class OrderByEmailSpecification
    :BaseSpecification<OrderEntity>
{
    public OrderByEmailSpecification(string email)
        :base(o => o.UserEmail == email)
    {
        AddInclude(o => o.Items);
        AddInclude(o => o.DeliveryMethod!);

        AddOrderBy(o => o.OrderDate);
    }
}
