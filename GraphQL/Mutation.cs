using System;
using Market.Abstractions;
using Market.Contracts.Requests.Categories;
using Market.Contracts.Requests.Products;
using Market.Contracts.Requests.Stores;
using Market.Contracts.Responses;

namespace Market.GraphQL
{
	public class Mutation
	{
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IStoreService _storeService;
        public Mutation(IProductService productService, ICategoryService categoryService, IStoreService storeService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _storeService = storeService;
        }

        public int AddProduct(ProductCreateRequest productCreate) => _productService.AddProduct(productCreate);
        public bool DeleteProduct(int id) => _productService.DeleteProduct(id);
        public bool UpdatePrice(int id, int price) => _productService.UpdatePrice(id, price);

        public int AddCategoriy(CategoryCreateRequest createCategoryRequest) => _categoryService.AddCategory(createCategoryRequest);

        public int AddStore(StoreCreateRequest storeCreate) => _storeService.AddStore(storeCreate);
       
    }
}

