using System;
using Market.Models;

namespace Market.Contracts.Requests.Products
{
	public class ProductCreateRequest
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public int? CategoryId { get; set; }
        public int? StoreId { get; set; }
    }
}

