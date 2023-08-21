using AutoMapper;
using ShopingCart.Application.Models.DTOs.CartItemDTOs;
using ShopingCart.Application.Models.DTOs.CategoryDTOs;
using ShopingCart.Application.Models.DTOs.CustomerDTOs;
using ShopingCart.Application.Models.DTOs.ItemsDTOs;
using ShopingCart.Application.Models.DTOs.UserDTOs;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Application.ProfileMapper
{
    public class AutoProfileConfiguration : Profile
    {
        public AutoProfileConfiguration()
        {
            // Mapper User
            CreateMap<Users, UserDTOs>().ReverseMap();
            CreateMap<Users, UserViewModelRes>().ReverseMap();
            CreateMap<Users, UserViewModelReq>().ReverseMap();
            CreateMap<UserViewModelReq, UserViewModelRes>().ReverseMap();

            // Mapper Category
            CreateMap<Category, CategoryDTOs>().ReverseMap();
            CreateMap<CategoryViewModelRes, CategoryDTOs>().ReverseMap();
            CreateMap<CategoryViewModelReq, CategoryDTOs>().ReverseMap();
            CreateMap<CategoryViewModelReq, CategoryViewModelRes>().ReverseMap();


            CreateMap<CategoryViewModelRes, Category>().ReverseMap();
            CreateMap<CategoryViewModelReq, Category>().ReverseMap();
            CreateMap<CategoryViewModelReq, CategoryViewModelRes>().ReverseMap();



            // Mapper Items
            CreateMap<Items, ItemsDTOs>().ReverseMap();
            CreateMap<Items, ItemsViewModelRes>().ReverseMap();
            CreateMap<Items, ItemsViewModelReq>().ReverseMap();
            CreateMap<ItemsViewModelReq, ItemsViewModelRes>().ReverseMap();


            // Mapper CartItem
            CreateMap<CartItem, CartItemDTOs>().ReverseMap();
            CreateMap<CartItem, CartItemViewModelRes>().ReverseMap();
            CreateMap<CartItem, CartItemViewModelReq>().ReverseMap();
            CreateMap<CartItemViewModelReq, CartItemViewModelRes>().ReverseMap();

            // Mapper Customer
            CreateMap<Customer, CustomerDTOs>().ReverseMap();
            CreateMap<Customer, CustomerViewModelRes>().ReverseMap();
            CreateMap<Customer, CustomerViewModelReq>().ReverseMap();
            CreateMap<CustomerViewModelReq, CustomerViewModelRes>().ReverseMap();



        }
    }
}
