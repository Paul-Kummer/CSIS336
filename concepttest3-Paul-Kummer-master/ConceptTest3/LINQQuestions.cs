using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTest3
{
    public class LINQQuestions
    {
        public void Execute()
        {
            // The following questions deal with a list of order initialized here.  To see the UML diagram
            // for Order, see OrderClassDiagram.cd
            var orders = OrderFactory.GetOrders();

            //----------------------------------------------------------------------------------------------------------
            // Question #1: Write a LINQ query (using method-call syntax) named customersWithBigOrders which selects 
            //              all orders with a total greater than $1000.  Return an anonymous type containing the 
            //              customer, OrderId and OrderTotal.

            var customersWithBigOrders = orders.Select(ord => new { ord.Customer, ord.OrderId, ord.OrderTotal })
                                                .Where(ord => ord.OrderTotal > 1000);

            customersWithBigOrders.Display("LINQ Question #1");

            //----------------------------------------------------------------------------------------------------------
            // Question #2: Write a LINQ query (using method-call syntax) named avgPricePerItem which selects all orders 
            //              and creates a new range variable named AveragePricePerItem.  Use this new range variable 
            //              to sort the results by the average price per item from highest to lowest.  Return an 
            //              anonymous type containing the order and the average price per item.

            var avgPricePerItem = orders.Select(ord => new { ord, AveragePricePerItem = ord.OrderTotal / ord.NumberOfItems })
                .OrderByDescending(ord => ord.AveragePricePerItem);


            avgPricePerItem.Display("LINQ Question #2");

            //----------------------------------------------------------------------------------------------------------
            // Question #3: Write a LINQ query (using method-call syntax) named ordersByCustomerLastName which returns 
            //              all orders sorted by customer last name.  Return an anonymous type containing the customer 
            //              and order.

            var ordersByCustomerLastName = orders.Select(ord => new { ord.Customer, ord}).OrderBy(ord => ord.Customer.LastName);

            ordersByCustomerLastName.Display("LINQ Question #3");

        }
    }
}
