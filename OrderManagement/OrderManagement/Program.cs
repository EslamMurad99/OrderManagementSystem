using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Repositories;
using System;

namespace OrderManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //  Add service of connection string
            builder.Services.AddDbContext<OrderManagementDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<OrderService>();


            // Services of Dependancy Injection (DI)
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

           

            // add policy to connect angular
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
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
        }
    }
}
