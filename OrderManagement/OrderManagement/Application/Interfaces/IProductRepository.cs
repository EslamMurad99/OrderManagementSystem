using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces
{
    public interface IProductRepository
    {
        public Product GetById(int id);
        public IEnumerable<Product> GetAll(); 
        public void Add(Product product);
        public void Save();
    }
}
