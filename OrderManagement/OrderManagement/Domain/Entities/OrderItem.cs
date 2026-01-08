using OrderManagement.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public Money UnitPrice { get; set; }

        private OrderItem() { }

        public OrderItem(int id, int productId, int quantity, Money unitPrice) //internal
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
