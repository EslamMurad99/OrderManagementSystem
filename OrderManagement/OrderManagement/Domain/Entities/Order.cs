using OrderManagement.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? CompletedDate { get; set; }

        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        public Order() { }

        public static Order Create(int id, int customerId)
        {
            return new Order 
            { 
                Id = id, 
                CustomerId = customerId, 
                Status = OrderStatus.Draft 
            };
        }

        public void AddItem(int id, int productId, int quantity, Money unitPrice)
        {
            if (Status == OrderStatus.Completed) 
                throw new InvalidOperationException("Cannot modify completed order.");
            if (quantity <= 0) 
                throw new ArgumentException("Quantity must be greater than zero.");

            var item = new OrderItem(id, productId, quantity, unitPrice);
            _items.Add(item);
        }

        public void RemoveItem(int itemId)
        {
            if (Status == OrderStatus.Completed) throw new InvalidOperationException("Cannot modify completed order.");

            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item == null) throw new ArgumentException("Item not found.");
            _items.Remove(item);
        }

        public Money GetTotal()
        {
            return new Money(_items.Sum(i => i.Quantity * i.UnitPrice.MoneyValueAmount));
        }

        public void Complete()
        {
            if (Status == OrderStatus.Completed) throw new InvalidOperationException("Order already completed.");
            Status = OrderStatus.Completed;
            CompletedDate = DateTime.UtcNow;
        }
    }
}
