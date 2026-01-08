using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces
{
    public interface ICustomerRepository
    {
        public Customer GetById(int id);
        public IEnumerable<Customer> GetAll();
        public void Add(Customer product);
        public void Save();
    }
}
