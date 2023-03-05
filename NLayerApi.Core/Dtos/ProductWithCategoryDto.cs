using NLayerApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Core.Dtos
{
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto CategoryDto { get; set; }
        //Geriye cevrilmis data gelecek deyene dto-lu varianti yazdiq
    }
}
