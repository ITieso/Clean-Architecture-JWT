using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestCommand.Categories
{
    public class UpdateCategoryRequest : IRequest<Category>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
