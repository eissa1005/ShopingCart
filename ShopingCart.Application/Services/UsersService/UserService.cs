using AutoMapper;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Repositories;
using ShopingCart.Application.Core.Services;
using ShopingCart.Application.Models.DTOs.UserDTOs;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Application.Services.ServiceUsers
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly ILoggerService logService;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork uow, ILoggerService logService, IMapper mapper)
        {
            this.uow = uow;
            this.logService = logService;
            this.mapper = mapper;
        }

        public async Task<UserViewModelRes> CreateUser(UserViewModelReq request)
        {
            var userEnitiy = mapper.Map<User>(request);
            var user = await uow.Repository<User>().AddAsync(userEnitiy);
            await uow.SaveChangesAsync();
            var userDTOs = mapper.Map<UserDTOs>(user);
            return new UserViewModelRes() { Data = userDTOs };

        }

        public async Task<int> DeleteUser(UserViewModelReq request)
        {
            var user = mapper.Map<User>(request);
            if (user == null)
            {
                logService.LogError("User is Empty");
                return await Task.FromResult(0);
            }

            uow.Repository<User>().Delete(user);
            int result = await uow.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateUser(UserViewModelReq request)
        {
            var user = await uow.Repository<User>().GetById(request.ID);
            if (user == null)
            {
                logService.LogError("User is Not Exists in database");
                return await Task.FromResult(0);
            }

            uow.Repository<User>().Update(user);
            int result = await uow.SaveChangesAsync();
            return result;
        }
    }
}
