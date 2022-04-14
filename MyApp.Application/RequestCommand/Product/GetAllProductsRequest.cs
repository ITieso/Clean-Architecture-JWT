using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.Response.Products;

namespace MyApp.Application.RequestCommand.Products
{
    public class GetAllProductsRequest : IRequest<IEnumerable<ProductResponse>>
    {
    }
}
