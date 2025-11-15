using E_Commerce.Service.Abstraction;
using E_Commerce.Shared.DataTransferObjects.UserOrder;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.API.Controllers;

public class OrderController(IOrderService order)
    : APIBaseController
{
    [HttpPost]
    public async Task<ActionResult<OrderResponse>> Create(OrderRequest request)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await order.CreateAsync(request, email);
        return HandleResult(result);
    }
}
