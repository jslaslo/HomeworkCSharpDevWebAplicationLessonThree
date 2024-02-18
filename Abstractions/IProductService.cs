using System;
using Market.Contracts.Requests.Products;
using Market.Contracts.Responses;

namespace Market.Abstractions
{
	public interface IProductService
	{
        public int AddProduct(ProductCreateRequest product);
        public IEnumerable<ProductResponse> GetProducts();

        public ProductResponse GetProductById(int id);
        public bool DeleteProduct(int id);
        public bool UpdatePrice(int idProduct, int price);
        public bool DeleteCategory(string category);
    }
}

