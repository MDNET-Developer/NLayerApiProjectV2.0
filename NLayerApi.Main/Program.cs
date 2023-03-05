using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayerApi.Core.Repositories;
using NLayerApi.Core.Service;
using NLayerApi.Core.UnitOfWork;
using NLayerApi.Main.Filters;
using NLayerApi.Repository.Context;
using NLayerApi.Repository.Repositories;
using NLayerApi.Repository.UnitOfWork;
using NLayerApi.Service.Mapping;
using NLayerApi.Service.Services;
using NLayerApi.Service.Validator;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt=>opt.Filters.Add(new ValidateFilterAtribute())).AddFluentValidation(options =>
    options.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

//Burada ASP.NET-in default oz filteri var onu baglayaq
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Generic oldugu ucun typeof istifade olundu
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile(new MapperProfile());
});

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {//Demeli biz burada yaradacagimiz migrationun yerini teyin edirik. Istesek eger options.MigrationsAssembly("NLayerApi.Repository") kimide yazib yerini teyin ede bilerik. Sadece ne vaxtsa biz bu qatmanin adini deyissek eger mecbur burada gelib deyismeliyik. Asagidaki kodun izahi ile desek Assemblyden AppDbContext olan qatmanin adini alacaq 
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
