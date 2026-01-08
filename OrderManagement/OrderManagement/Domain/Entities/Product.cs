using OrderManagement.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = ""; // = string.Empty;
        public Money PriceMoney { get; set; }

        public Product() { } // private --> For EF Core

        public static Product Create(string name, decimal price)//int id, 
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("Name is required.");
            if (price < 0) 
                throw new ArgumentException("Price must be greater than or equal to zero.");

            return new Product{ };
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) 
                throw new ArgumentException("Price must be greater than or equal to zero.");
            //PriceMoney = newPrice;
        }
    }
}
