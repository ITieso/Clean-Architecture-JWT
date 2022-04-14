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

namespace MyApp.Application.RequestHandler.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, ProductResponse>
    {
        private readonly IProductService _productService;
        public GetProductByIdHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(request.Id);
            if (product == null)
                throw new ApplicationException("Product not found");

            var response = new ProductResponse();
            response.MapToResponse(product);
            return response;
        }
    }
}
