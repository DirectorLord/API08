namespace E_Commerce.Service.Specifications;

public class GetProductsByUdsSpecification(List<int> ids)
    : BaseSpecification<Product>(p => ids.Contains(p.Id));
