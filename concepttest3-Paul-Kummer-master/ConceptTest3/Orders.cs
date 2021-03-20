using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTest3
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public int NumberOfItems { get; set; }
        public Decimal OrderTotal { get; set; }
        public Customer Customer { get; set; }
        public override string ToString() => $"{OrderId}:{OrderDate,10:d} {Description,-25} {OrderTotal:C}";

    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() => $"{CustomerId}:{FirstName} {LastName}";
    }

    public static class OrderFactory
    {
        public static Order[] GetOrders()
        {
            Order[] orders = {
                new Order()
                {
                    OrderId = 1001,
                    OrderDate = new DateTime(2020,01,15),
                    Description = "Custom graphics",
                    NumberOfItems = 20,
                    OrderTotal = 123.45m,
                    Customer = new Customer()
                    {
                        CustomerId = 1001,
                        FirstName = "John",
                        LastName = "Wemmick"
                    }
                },
                new Order()
                {
                    OrderId = 1002,
                    OrderDate = new DateTime(2020,02,22),
                    Description = "Snow Gear",
                    NumberOfItems = 35,
                    OrderTotal = 3423.15m,
                    Customer = new Customer()
                    {
                        CustomerId = 1002,
                        FirstName = "Clara",
                        LastName = "Barley"
                    }
                },
                new Order()
                {
                    OrderId = 1003,
                    OrderDate = new DateTime(2019,11,22),
                    Description = "Turkey grilling equipment",
                    NumberOfItems = 7,
                    OrderTotal = 382.50m,
                    Customer = new Customer()
                    {
                        CustomerId = 1003,
                        FirstName = "Herbert",
                        LastName = "Pocket"
                    }
                },
                                new Order()
                {
                    OrderId = 1004,
                    OrderDate = new DateTime(2020,01,15),
                    Description = "Lawn Mower Repair",
                    NumberOfItems = 24,
                    OrderTotal = 1234.56m,
                    Customer = new Customer()
                    {
                        CustomerId = 1004,
                        FirstName = "Joe",
                        LastName = "Gargery"
                    }
                },
                new Order()
                {
                    OrderId = 1005,
                    OrderDate = new DateTime(2020,2,7),
                    Description = "Ice Fishing Equipment",
                    NumberOfItems = 3,
                    OrderTotal = 123.15m,
                    Customer = new Customer()
                    {
                        CustomerId = 1005,
                        FirstName = "Arthur",
                        LastName = "Havisham"
                    }
                },
                new Order()
                {
                    OrderId = 1006,
                    OrderDate = new DateTime(2019,10,22),
                    Description = "Halloween Decorations",
                    NumberOfItems = 8,
                    OrderTotal = 73.50m,
                    Customer = new Customer()
                    {
                        CustomerId = 1006,
                        FirstName = "Bentley",
                        LastName = "Drummle"
                    }
                }
            };
            return orders;
        }
    }
    public static class IEnumerableExtensions
    {
        public static void Display(this IEnumerable list, string header)
        {
            Console.WriteLine($"\n{header}:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
