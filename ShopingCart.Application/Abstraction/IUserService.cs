using ShopingCart.Application.Models.DTOs.UserDTOs;

namespace ShopingCart.Application.Abstraction
{
    public interface IUserService
    {
        Task<UserViewModelRes> CreateUser(UserViewModelReq request);
        Task<int> UpdateUser(UserViewModelReq request);
        Task<int> DeleteUser(UserViewModelReq request);


    }
}
