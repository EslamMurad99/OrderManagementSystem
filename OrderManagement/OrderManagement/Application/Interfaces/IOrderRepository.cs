using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderRepository
    {
        public Order GetById(int id);
        public void Add(Order orderAdd);
        public List<Order> GetAll();
        public void Save();
    }
}
