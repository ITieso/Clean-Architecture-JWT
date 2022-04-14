using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.Response.Products;

namespace MyApp.Application.RequestCommand.Product
{
    public class GetProductByIdRequest : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}
