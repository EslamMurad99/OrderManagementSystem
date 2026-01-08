using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        OrderManagementDbContext context;
        public CustomerRepository(OrderManagementDbContext ctx)
        {
            this.context = ctx;
        }
        public void Add(Customer product)
        {
            context.TbCustomers.Add(product);
            Save();
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.TbCustomers.ToList();
        }

        public Customer GetById(int id)
        {
            return context.TbCustomers.FirstOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
