using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; } = "";   //= string.Empty;

        public Customer() { }

        public static Customer Create(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("Name is required.");
            return new Customer { Id = id, Name = name };
        }
    }
}
