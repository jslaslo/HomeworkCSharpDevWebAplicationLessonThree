using System;
using AutoMapper;
using Market.Abstractions;
using Market.Context;
using Market.Contracts.Requests.Products;
using Market.Contracts.Responses;
using Market.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Market.Services
{
    public class ProductService : IProductService
    {
        private readonly MarketContext _marketContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCash;


        public ProductService(MarketContext context, IMapper mapper, IMemoryCache memoryCash)
        {
            _marketContext = context;
            _mapper = mapper;
            _memoryCash = memoryCash;
        }
        public int AddProduct(ProductCreateRequest product)
        {

            var mapEntity = _mapper.Map<Product>(product);
            _marketContext.Products.Add(mapEntity);
            _marketContext.Stores.FirstOrDefault(s => s.Id == product.StoreId).Count = + 1;
            _marketContext.Stores.FirstOrDefault(s => s.Id == product.StoreId).Products.Add(mapEntity);

            _marketContext.SaveChanges();
            _memoryCash.Remove("products");
            return mapEntity.Id;


        }

        public bool DeleteCategory(string category)
        {
            try
            {
                var deleteCategory = _marketContext.Products.Where(c => c.Description == category).FirstOrDefault();
                deleteCategory.Description = null;
                _marketContext.SaveChanges();
                _memoryCash.Remove("products");
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteProduct(int id)
        {
            var deleteProduct = _marketContext.Products.FirstOrDefault(p => p.Id == id);
            if (deleteProduct != null)
            {
                _marketContext.Products.Remove(deleteProduct);
                _marketContext.SaveChanges();
                _memoryCash.Remove("products");
                return true;
            }
            else
            {
                return false;
            }
        }

        public ProductResponse GetProductById(int id)
        {
            var product = _marketContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            return _mapper.Map<ProductResponse>(product);
        }

        public IEnumerable<ProductResponse> GetProducts()
        {
            if (_memoryCash.TryGetValue("products", out List<ProductResponse> result))
            {
                return result!;
            }
            IEnumerable<ProductResponse> products = _marketContext.Products.Select(_mapper.Map<ProductResponse>).ToList();

            _memoryCash.Set("products", products, TimeSpan.FromMinutes(30));

            return products;
        }

        public bool UpdatePrice(int idProduct, int price)
        {
            try
            {
                var product = _marketContext.Products.FirstOrDefault(c => c.Id == idProduct);
                product.Price = price;
                _marketContext.SaveChanges();
                _memoryCash.Remove("products");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

