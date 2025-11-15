using E_Commerce.Service.Abstraction;
using E_Commerce.Shared.DataTransferObjects;
using E_Commerce.Shared.DataTransferObjects.UserOrder;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.API.Controllers;

public class OrderController(IOrderService service)
    : APIBaseController
{
    [HttpPost]
    public async Task<ActionResult<OrderResponse>> Create(OrderRequest request, CancellationToken cancellationToken)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await service.CreateAsync(request, email, cancellationToken);
        return HandleResult(result);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await service.GetOrderAsync(email, id, cancellationToken);
        return HandleResult(result);
    }
    [HttpGet]
    public async Task<ActionResult<OrderResponse>> Get(CancellationToken cancellationToken)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await service.GetAllAsync(email, cancellationToken);
        return Ok(result);
    }

    [HttpGet("DeliveryMethods")]
    public async Task<ActionResult<IEnumerable<DeliveryMethodResponse>>> GetDeliveryMethod( CancellationToken cancellationToken)
    {
        var methods = await service.GetDeliveryMethodAsync(cancellationToken);
        return Ok(methods);
    }
}
