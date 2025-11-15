using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Service.Abstraction.Common;
using E_Commerce.Service.Specifications;
using E_Commerce.Shared.DataTransferObjects.UserOrder;

namespace E_Commerce.Service.Services;

public class OrderService(IUnitOfWork unitOfWork, IMapper mapper, IBasketRepository repository)
    : IOrderService
{
    public async Task<Result<OrderResponse>> CreateAsync(OrderRequest request, string email)
    {
        var basket = await repository.GetAsync(request.basketId);
        if (basket == null) return Error.NotFound("Basket was not found", $"Basket with Id {request.basketId} was not found");
        var method = await unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(request.DeliveryMethodId);
        if (method == null) return Error.NotFound("Delivery method was not found");

        var productRepo = unitOfWork.GetRepository<Product, int>();
        var ids = basket.Items.Select(i => i.Id).ToList();
        var products = (await productRepo.GetAllAsync(new GetProductsByUdsSpecification(ids))).ToDictionary(p => p.Id);
        var orderItems = new List<OrderItem>();

        var validationError = new List<Error>();
        foreach(var item in basket.Items)
        {
            
            if(!products.TryGetValue(item.Id, out Product? product))
            {
                validationError.Add(Error.NotFound("Product not found", $"Product with Id {item.Id} was not found"));
                continue;
            }
            var orderItem = new OrderItem
            {
                Price = product.Price,
                Quantity = item.Quantity,
                Product = new ProductInOrderItem
                {
                    Name = product.Name,
                    PictureUrl = product.PictureUrl,
                    ProductId = product.Id
                }
            };
            orderItems.Add(orderItem);
        }
        if (validationError.Any()) return validationError;

        var subtotal =  orderItems.Sum(i => i.Quantity * i.Price);
        var address = mapper.Map<OrderAddress>(request.Address);

        var order = new OrderEntity
        {
            DeliveryMethod = method,
            UserEmail = email,
            Items = (ICollection<OrderEntity>)orderItems,
            Subtotal = subtotal,
            Address = address,

        };
        var orderRepo = unitOfWork.GetRepository<OrderEntity, Guid>();
        orderRepo.Add(order);
        await unitOfWork.SaveCHangesAsync();
        return mapper.Map<OrderResponse>(order);
    }
}
