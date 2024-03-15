using Appication.PayLoads.Converter;
using Appication.PayLoads.Converter.SanPhamConverter;
using Appication.Service;
using Application.PayLoads.Converter;
using Application.PayLoads.DataResponse;
using Application.PayLoads.Response;
using Application.Service;
using Infrastructure.Data;
using Infrastructure.Interface;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepositories, ProductRepositories>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ProductConverter>();
builder.Services.AddScoped<ProductVariantsConverter>();
//ProductVariant
builder.Services.AddScoped<IProductVariantRepositories, ProductVariantRepositories>();
builder.Services.AddScoped<IProductVariantServices, ProductVariantServices>();
builder.Services.AddScoped<VariantPropertiesConverter>();
builder.Services.AddScoped<ProductVariantWithVariantPropertiesConverter>();
builder.Services.AddScoped<ProductVariant_Product_Converter>();
builder.Services.AddScoped<ProductVariantWithVariantPropertiesConverter>();
builder.Services.AddScoped<VariantProperty_Product_Converter>();
builder.Services.AddScoped<DetailConverter>();
builder.Services.AddScoped<ProductInformationConverter>();

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
