using Microsoft.AspNetCore.Http.HttpResults;
using OrderManagement.Application.DTO;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.ValueObjects;

namespace OrderManagement.Application.Services
{
    public class ProductService
    {
       IProductRepository iProductRepository;

        public ProductService(IProductRepository repository)
        {
            iProductRepository = repository;
        }

        public int CreateProduct(string name, decimal price) // int id,
        {
            var money = new Money(price); 
            var product = Product.Create(name, price);
            iProductRepository.Add(product);
            iProductRepository.Save();
            return product.Id;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = iProductRepository.GetAll();
            return products.Select(p => new ProductDto()); // obj is null
        }

        public ProductDto GetProductById(int id)
        {
            var product = iProductRepository.GetById(id);
            return product == null ? null : new ProductDto();  // obj is null
        }
    }
}
