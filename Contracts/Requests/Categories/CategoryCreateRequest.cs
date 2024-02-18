using System;
namespace Market.Contracts.Requests.Categories
{
	public class CategoryCreateRequest
	{
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}

