using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.ValueObjects
{
    public record Money
    {
        
        public decimal MoneyValueAmount { get; private set; }
        public Money() { }
        public Money(decimal value)
        {
            if (value < 0)
            {  
                throw new ArgumentOutOfRangeException("Price is Invalid");
                //Console.WriteLine("Price is Invalid");
            }
            MoneyValueAmount = value;
        }
        /*
         public static Money operator +(Money a, Money b)
        => new Money(a.Amount + b.Amount);

    public static Money operator *(Money money, int qty)
        => new Money(money.Amount * qty);
         */
    }
}
