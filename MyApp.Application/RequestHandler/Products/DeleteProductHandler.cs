using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.IService.IProductService;
using MyApp.Application.RequestCommand.Product;
using MyApp.Application.Response.Products;

namespace MyApp.Application.RequestHandler.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, ProductResponse>
    {
        private readonly IProductService _productService;
        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(request.Id);
            var removed = await _productService.Remove(product);

            ProductResponse response = new ProductResponse();
            response.MapToResponse(removed);

            return response;

        }
    }
}
