using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get;  set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            Name = name;
        }
        
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
