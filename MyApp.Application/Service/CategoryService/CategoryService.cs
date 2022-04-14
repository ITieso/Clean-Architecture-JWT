using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MyApp.Application.IService.ICategoryService;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Create(Category category)
        {
             var categoryEntity = await _categoryRepository.CreateAsync(category);
             return categoryEntity;
        }

        public async Task<Category> Delete(Category category)
        {
           return await _categoryRepository.DeleteAsync(category);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
           return  await _categoryRepository.GetAll();
        }

        public Task<Category> GetCategoryByIdAsync(int? id)
        {
            var categoryEntity = _categoryRepository.GetCategoryByIdAsync(id);
            return categoryEntity;
        }

        public async Task<Category> Update(Category category)
        {
            Category currentCategory = await GetCategoryByIdAsync(category.Id);
            currentCategory.Name = category.Name;

            var response = await _categoryRepository.UpdateAsync(currentCategory);
            return response;
        }
    }
}
