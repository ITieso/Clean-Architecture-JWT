using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Domain.Entities;

namespace MyApp.Application.IService.ICategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int? id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(Category category);

    }
}
