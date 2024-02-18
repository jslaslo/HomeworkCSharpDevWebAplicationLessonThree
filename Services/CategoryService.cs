using System;
using AutoMapper;
using Market.Abstractions;
using Market.Context;
using Market.Contracts.Requests.Categories;
using Market.Contracts.Responses;
using Market.Models;

namespace Market.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly MarketContext _storeContext;

        public CategoryService(MarketContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }
        public int AddCategory(CategoryCreateRequest createCategoryRequest)
        {
            var mapEntity = _mapper.Map<Category>(createCategoryRequest);
            _storeContext.Categories.Add(mapEntity);
            _storeContext.SaveChanges();

            return mapEntity.Id;
        }

        public IEnumerable<CategoryResponse> GetCategories()
        {
            IEnumerable<CategoryResponse> products = _storeContext.Categories.Select(_mapper.Map<CategoryResponse>);

            return products;
        }
    }
}

