using OrderManagement.Application.DTO;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        OrderManagementDbContext context;
        public ProductRepository(OrderManagementDbContext ctx) 
        {
            this.context = ctx;
        }
        public void Add(Product product)
        {
            context.TbProducts.Add(product);
            Save();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.TbProducts.ToList();
        }

        public Product GetById(int id)
        {
            return context.TbProducts.FirstOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
