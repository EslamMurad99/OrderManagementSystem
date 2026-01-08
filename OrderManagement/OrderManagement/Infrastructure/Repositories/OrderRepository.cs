using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        OrderManagementDbContext context;
        public OrderRepository(OrderManagementDbContext ctx)
        {
            this.context = ctx;
        }
        public void Add(Order orderAdd)
        {
            context.TbOrders.Add(orderAdd);
            Save();
        }

        public List<Order> GetAll()
        {
            return context.TbOrders.ToList();
        }

        public Order GetById(int id)
        {
            return context.TbOrders.FirstOrDefault(o => o.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
