using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestCommand.Categories
{
    public class DeleteCategoryRequest : IRequest<Category>
    {
        public int Id { get; set; }
    }
}
