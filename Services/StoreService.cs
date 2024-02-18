using System;
using AutoMapper;
using Market.Abstractions;
using Market.Context;
using Market.Contracts.Requests.Categories;
using Market.Contracts.Requests.Stores;
using Market.Contracts.Responses;
using Market.Models;

namespace Market.Services
{
    public class StoreService : IStoreService
    {
        private readonly IMapper _mapper;
        private readonly MarketContext _storeContext;

        public StoreService(MarketContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }
        public int AddStore(StoreCreateRequest createStoreRequest)
        {
            var mapEntity = _mapper.Map<Store>(createStoreRequest);
            _storeContext.Stores.Add(mapEntity);
            _storeContext.SaveChanges();

            return mapEntity.Id;
        }

        public IEnumerable<ProductResponse> GetProductsInStore(int id)
        {
            Store? store = _storeContext.Stores.FirstOrDefault(s => s.Id == id);
            IEnumerable<ProductResponse> products = store.Products.Select(_mapper.Map<ProductResponse>).ToList();            
           
            return products;
        }
        public int GetCountInStore(int id)
        {
            Store? store = _storeContext.Stores.FirstOrDefault(s => s.Id == id );
            return store.Count;
        }
    }
}

