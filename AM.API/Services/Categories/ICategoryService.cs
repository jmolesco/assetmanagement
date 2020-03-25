using AM.API.DTOs.Categories;
using AM.API.Helpers;
using AM.Core.Domain.Categories;
using AutoMapper;

namespace AM.API.Services.Categories
{
    public interface ICategoryService
    {

        /// <summary>
        /// Add new Category
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        object Add(Category category);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get Category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update Category record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category">Category</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateCategory category, IMapper mapper);

        object Delete(int id);

    }
}
