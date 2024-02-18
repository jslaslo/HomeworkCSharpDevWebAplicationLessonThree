using System;
using Market.Contracts.Requests.Categories;
using Market.Contracts.Requests.Products;
using Market.Contracts.Requests.Stores;
using Market.Contracts.Responses;

namespace Market.Abstractions
{
	public interface IStoreService
	{
        int AddStore(StoreCreateRequest CreateStoreRequest);
        IEnumerable<ProductResponse> GetProductsInStore(int id);
        int GetCountInStore(int id);
    }
}

