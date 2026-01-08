using OrderManagement.Domain.ValueObjects;

namespace OrderManagement.Application.DTO
{
    public record OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? CompletedDate { get; set; }
        public IReadOnlyCollection<OrderItemDto> Items { get; set; }
    }
}
