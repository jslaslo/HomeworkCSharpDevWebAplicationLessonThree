using System;
using AutoMapper;
using Market.Contracts.Requests.Categories;
using Market.Contracts.Requests.Products;
using Market.Contracts.Requests.Stores;
using Market.Contracts.Responses;
using Market.Models;

namespace Market.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductCreateRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductDeleteRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductUpdateRequest>(MemberList.Destination).ReverseMap();

            CreateMap<Category, CategoryCreateRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Category, CategoryResponse>(MemberList.Destination).ReverseMap();

            CreateMap<Store, StoreCreateRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Store, StoreResponse>(MemberList.Destination).ReverseMap();


        }

    }
}

