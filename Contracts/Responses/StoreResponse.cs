using System;
using Market.Models;

namespace Market.Contracts.Responses
{
	public class StoreResponse
	{
        public int Id { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

