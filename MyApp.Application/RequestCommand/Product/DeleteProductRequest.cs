using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.Response.Products;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestCommand.Product
{
    public class DeleteProductRequest : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}
