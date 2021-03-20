using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTest2
{
    public class LINQQuestions
    {
        public void Execute()
        {
            // The following questions deal with a list of order initialized here.  To see the UML diagram
            // for Order, see OrderClassDiagram.cd
            var orders = OrderFactory.GetOrders();

            //----------------------------------------------------------------------------------------------------------
            // Question #1: Write a LINQ query (using SQL-like syntax) named customersWithBigOrders which selects 
            //              all orders with a total greater than $1000.  Return an anonymous type containing the 
            //              customer, OrderId and OrderTotal.
            
            var customersWithBigOrders = from tmpOrd in orders
                                         where tmpOrd.OrderTotal > 1000
                                         select new { tmpOrd.Customer, tmpOrd.OrderId, tmpOrd.OrderTotal };

            customersWithBigOrders.Display("LINQ Question #1");

            //----------------------------------------------------------------------------------------------------------
            // Question #2: Write a LINQ query (using SQL-like syntax) named avgPricePerItem which selects all orders 
            //              and creates a new range variable named AveragePricePerItem.  Use this new range variable 
            //              to sort the results by the average price per item from highest to lowest.  Return an 
            //              anonymous type containing the order and the price per item.

            var avgPricePerItem = from tmpOrd in orders
                                  let AveragePricePerItem = Math.Round(tmpOrd.NumberOfItems / tmpOrd.OrderTotal, 2) // currency formatting is not used in the output, so I rounded here
                                  orderby AveragePricePerItem descending
                                  select new { tmpOrd, AveragePricePerItem };

            avgPricePerItem.Display("LINQ Question #2");

            //----------------------------------------------------------------------------------------------------------
            // Question #3: Write a LINQ query (using SQL-like syntax) named ordersByCustomerLastName which returns 
            //              all orders sorted by customer last name.  Return an anonymous type containing the customer 
            //              and order.

            var ordersByCustomerLastName = from tmpOrd in orders
                                           orderby tmpOrd.Customer.LastName
                                           select new { tmpOrd.Customer, tmpOrd };

            ordersByCustomerLastName.Display("LINQ Question #3");

            //----------------------------------------------------------------------------------------------------------
            // Question #4: Write a LINQ query (using SQL-like syntax) named allOrderTotals which returns just the order 
            //              total from each order.

            var allOrderTotals = from tmpOrd in orders
                                 select tmpOrd.OrderTotal;

            allOrderTotals.Display("LINQ Question #4");

            //----------------------------------------------------------------------------------------------------------
            // Question #5: Using allOrderTotals from above, write a statement that assigns the sum of all of the 
            //              order totals to variable allOrderTotalsSum.

            var allOrderTotalsSum = allOrderTotals.Sum();

            Console.WriteLine($"\nLINQ Question #5:\nThe sum of all orders is {allOrderTotalsSum:C}");

            //----------------------------------------------------------------------------------------------------------
            // Question #6: Using allOrderTotals and allOrderTotalsSum from above, write a statement that assigns
            //              the average of all order totals to the variable allOrderTotalAverage.

            var allOrderTotalAverage = allOrderTotalsSum / allOrderTotals.Count();
            //var allOrderTotalAverage = allOrderTotals.Average(); This is the better way of doing it

            Console.WriteLine($"\nLINQ Question #6:\nThe average of all orders is {allOrderTotalAverage:C}");

        }
    }
}
