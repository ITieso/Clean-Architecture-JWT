using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.IService.ICategoryService;
using MyApp.Application.RequestCommand.Categories;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestHandler.Categories
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, Category>
    {
        private readonly ICategoryService _categoryService;
        public DeleteCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<Category> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(request.Id);

            if (category == null)
                throw new ApplicationException("Category not found");

            var response = await _categoryService.Delete(category);
            return response;
               
        }
    }
}
