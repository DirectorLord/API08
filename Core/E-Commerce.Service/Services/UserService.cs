using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Service.Abstraction.Common;
using E_Commerce.Service.Contracts;
using E_Commerce.Shared.DataTransferObjects.Auth;
using E_Commerce.Shared.DataTransferObjects.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Service.Services;

public class UserService(UserManager<ApplicationUser> manager, ITokenService service, IMapper mapper)
    : IUserService
{
    public async Task<Result<UserResponse>> GetByEmailAsync(string email)
    {
        var user = await manager.FindByEmailAsync(email);
        if(user == null)
            return Error.NotFound("User not found", $"User with email {email} was not found");
        var roles = await manager.GetRolesAsync(user);
        return new UserResponse(user.Email, user.DisplayName, service.GetToken(user, roles));
    }

    public async Task<Result<AddressDTO>> GetAdressAsync(string email)
    {
        var user = await manager.Users.Include(u => u.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
            return Error.NotFound("User not found", $"User with email {email} was not found");
        if(user.Address == null)
            return Error.NotFound("Address not found", $"Address for user with email {email} was not found");
        return mapper.Map<AddressDTO>(user.Address);
    }

    public async Task<Result<AddressDTO>> UpdateAdressAsync(string email, AddressDTO adress)
    {
        var user = await manager.FindByEmailAsync(email);
        if (user == null)
            return Error.NotFound("User not found", $"User with email {email} was not found");
        if (user.Address != null)
        {
            user.Address.FirstName = adress.FirstName;
            user.Address.LastName = adress.LastName;
            user.Address.Street = adress.Street;
            user.Address.City = adress.City;
            user.Address.Country = adress.Country;
        }
        else
        {
            user.Address = mapper.Map<Address>(adress);
        }
        await manager.UpdateAsync(user);
        return mapper.Map<AddressDTO>(user.Address);
    }
}
