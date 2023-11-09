using AutoMapper;
using TilloBrand.Domain.Entities;
using TilloBrand.Service.DTOs.Markets;
using TilloBrand.Service.DTOs.Orders;
using TilloBrand.Service.DTOs.Products;
using TilloBrand.Service.DTOs.Users;


namespace TilloBrand.Service.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User Mapping
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        //Product Mapping
        CreateMap<Product, ProductForUpdateDto>().ReverseMap();
        CreateMap<Product, ProductForResultDto>().ReverseMap();
        CreateMap<Product, ProductForCreationDto>().ReverseMap();

        //Order Mapping
        CreateMap<Order, OrderForUpdateDto>().ReverseMap();
        CreateMap<Order, OrderForResultDto>().ReverseMap();
        CreateMap<Order, OrderForCreationDto>().ReverseMap();

        //Market Mapping
        CreateMap<Market, MarketForUpdateDto>().ReverseMap();
        CreateMap<Market, MarketForResultDto>().ReverseMap();
        CreateMap<Market, MarketForCreationDto>().ReverseMap();
    }
}
