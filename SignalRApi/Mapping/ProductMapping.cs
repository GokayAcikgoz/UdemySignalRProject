﻿using AutoMapper;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            //CategoryName özelliğini Product sınıfındaki Category nesnesinin CategoryName özelliğinden almasını söylüyoruz.
            CreateMap<Product, ResultProductWithCategory>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.CategoryStatus, opt => opt.MapFrom(src => src.Category.CategoryStatus))
                .ReverseMap();

        }
    }
}
