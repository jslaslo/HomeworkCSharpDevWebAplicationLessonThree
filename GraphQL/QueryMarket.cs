using System;
using Market.Abstractions;
using Market.Contracts.Requests.Stores;
using Market.Contracts.Responses;
using Market.Services;

namespace Market.GraphQL
{
	public class QueryMarket
	{
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IStoreService _storeService;
        public QueryMarket(IProductService productSrevice, ICategoryService categoryService, IStoreService storeService)
        {
            _productService = productSrevice;
            _categoryService = categoryService;
            _storeService = storeService;
        }
        public IEnumerable<CategoryResponse> GetCategories() => _categoryService.GetCategories();
        public IEnumerable<ProductResponse> GetProducts() => _productService.GetProducts();
        public ProductResponse GetProductById(int id) => _productService.GetProductById(id);
        public IEnumerable<ProductResponse> GetProductsInStore(int id) => _storeService.GetProductsInStore(id);
        public int GetCountInStore(int id) => _storeService.GetCountInStore(id);
    }
}

