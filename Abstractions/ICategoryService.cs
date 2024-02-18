using System;
using Market.Contracts.Requests.Categories;
using Market.Contracts.Responses;

namespace Market.Abstractions
{
	public interface ICategoryService
	{
        int AddCategory(CategoryCreateRequest createCategoryRequest);
        IEnumerable<CategoryResponse> GetCategories();
    }
}

