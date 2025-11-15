using E_Commerce.Service.Abstraction.Common;
using E_Commerce.Shared.DataTransferObjects.Auth;
using E_Commerce.Shared.DataTransferObjects.Users;

namespace E_Commerce.Service.Abstraction;

public interface IUserService
{
    Task<Result<UserResponse>> GetByEmailAsync(string email);
    Task<Result<AddressDTO>> GetAdressAsync(string email);
    Task<Result<AddressDTO>> UpdateAdressAsync(string email, AddressDTO adress);
}
