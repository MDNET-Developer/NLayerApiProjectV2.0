using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Repository.Confugirations
{
    public class CategoryConfugration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(55);

            builder.HasData
           (
                new Category { Id = 1, Name = "Laptops" },
                new Category { Id = 2, Name = "Tablets" },
                new Category { Id = 3, Name = "Smartphones" }

           );
        }
    }
}
