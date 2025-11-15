namespace E_Commerce.Service.Specifications;

internal class GetProductsByUdsSpecification(List<int> ids)
    : BaseSpecification<Product>(p => ids.Contains(p.Id));
