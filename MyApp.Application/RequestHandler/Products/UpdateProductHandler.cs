using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.IService.IProductService;
using MyApp.Application.RequestCommand.Product;
using MyApp.Application.Response.Products;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestHandler.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, ProductResponse>
    {
        private readonly IProductService _productService;
        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            Product productUpdated = new Product(request.Id, request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            var update = await _productService.Update(productUpdated);

            ProductResponse response = new ProductResponse();
            response.MapToResponse(update);

            return response;
        }
    }
}
