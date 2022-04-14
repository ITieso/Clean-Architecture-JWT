using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Context;

namespace MyApp.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            if (categories == null)
                throw new ApplicationException("Categories not found");
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int? id)
        {
           return await _context.Categories.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

    }
}
