using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.IService.ICategoryService;
using MyApp.Application.RequestCommand.Categories;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestHandler.Categories
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, Category>
    {
        private readonly ICategoryService _categoryService;
        public UpdateCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<Category> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            Category categoryUpdated = new Category(request.Id, request.Name);
            var response = await _categoryService.Update(categoryUpdated);
            return response;
        }
    }
}
