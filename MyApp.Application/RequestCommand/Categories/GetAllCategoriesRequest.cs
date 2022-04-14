using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.Response.Categories;

namespace MyApp.Application.RequestCommand.Categories
{
    public class GetAllCategoriesRequest : IRequest<IEnumerable<CategoryResponse>>
    {
    }
}
