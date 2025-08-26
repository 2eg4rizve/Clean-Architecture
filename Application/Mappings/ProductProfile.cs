using Application.Dtos.RequestDtos;
using Application.Dtos.ResponseDtos;
using AutoMapper;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Domain → Response DTO
            CreateMap<Product, ProductResponse>().ReverseMap();

            // Request DTO → Domain
            CreateMap<ProductRequest, Product>();
        }
    }
}
