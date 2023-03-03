using Microsoft.EntityFrameworkCore;
using NLayerApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Repository.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Yuxaridaki kimi yazsaq butun confugrationlar hamisi avtomat tetbiq olunacaq. Asagidaki kimi bir-bir yazmaga ehtiyac yoxdur
            /*
            modelBuilder.ApplyConfiguration(new CategoryConfugration());
            modelBuilder.ApplyConfiguration(new ProductConfugration());
            modelBuilder.ApplyConfiguration(new ProductFeatureConfugration());
            */
            //Verilen elave etmeyin 2-ci yolu. Lakin best practise baximindan meslehet gorulmur burda etmek
            modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature()
            {
                Id = 1,
                ProductId = 1,
                Width = 1,
                Height = 1,
                Color = "CyberSilver"
            },

            new ProductFeature()
            {
                Id = 2,
                ProductId = 2,
                Width = 2,
                Height = 3,
                Color = "OceanBlue"
            }
            );
        }
    }
}
