using OrderManagement.Application.DTO;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Services
{
    public class OrderService
    {
        IOrderRepository iOrderRepository;
        IProductRepository iProducctRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            iOrderRepository = orderRepository;
            iProducctRepository = productRepository;
        }

        public int CreateOrder(int id, int customerId)
        {
            var order = Order.Create(id, customerId);
            iOrderRepository.Add(order);
            iOrderRepository.Save();
            return order.Id;
        }

        public void AddItemToOrder(int orderId, int productId, int quantity)
        {
            var order = iOrderRepository.GetById(orderId) ?? 
                throw new KeyNotFoundException("Order not found.");
            var product = iProducctRepository.GetById(productId) ?? 
                throw new KeyNotFoundException("Product not found.");

            //order.AddItem(productId, quantity);
            iOrderRepository.Save();
        }

        public void RemoveItemFromOrder(int orderId, int itemId)
        {
            var order = iOrderRepository.GetById(orderId) ?? throw new KeyNotFoundException("Order not found.");
            order.RemoveItem(itemId);
            iOrderRepository.Save();
        }

        public void CompleteOrder(int orderId)
        {
            var order = iOrderRepository.GetById(orderId) ?? 
                throw new KeyNotFoundException("Order not found.");
            order.Complete();
            iOrderRepository.Save();
        }

        public OrderDto GetOrderById(int id)
        {
            var order = iOrderRepository.GetById(id);
            if (order == null) return null;

            var items = order.Items.Select(i => new OrderItemDto()).ToList();
            return new OrderDto();
        }
    }
}
