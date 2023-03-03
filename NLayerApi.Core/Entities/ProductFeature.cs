using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Core.Entities
{
    public class ProductFeature//BaseEntity verirem cunki ele Product-a baglidir
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
