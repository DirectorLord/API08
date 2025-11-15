using E_Commerce.Service.Abstraction;
using E_Commerce.Shared.DataTransferObjects.Auth;
using E_Commerce.Shared.DataTransferObjects.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.API.Controllers;
[ProducesResponseType<ProblemDetails>(StatusCodes.Status401Unauthorized)]
[Authorize]
public class UserController(IUserService userService)
    : APIBaseController
{
    [HttpGet("User")]
    public async Task<ActionResult<UserResponse>> GetUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await userService.GetByEmailAsync(email);
        return HandleResult(result);
    }
    [ProducesResponseType<AddressDTO>(200)]
    [HttpGet("Address")]
    public async Task<ActionResult<AddressDTO>> GetAddress()
    {
        string email = User.FindFirstValue(ClaimTypes.Email)!;
        var result = await userService.GetAdressAsync(email);
        return HandleResult(result);
    }
    [ProducesResponseType<AddressDTO>(200)]
    [HttpPut("Address")]
    public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO address)
    {
        string email = User.FindFirstValue(ClaimTypes.Email)!;
        var result = userService.UpdateAdressAsync(email, address);
        return HandleResult( await result);
    }
}
