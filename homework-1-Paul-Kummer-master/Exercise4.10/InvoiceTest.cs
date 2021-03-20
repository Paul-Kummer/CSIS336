using System;
using System.Collections.Generic;
using System.Text;

namespace exercise4._10
{
    class InvoiceTest
    {
        static void Main()
        {
            Invoice inv1 = new Invoice("1001", "rotary gurd", 2, 100.95m);
            Invoice inv2 = new Invoice("1002", "blinker fluid", 1, 0m);

            DisplayInvoice();

            inv1.PartNum = "2001";
            inv1.PartDescript = "Rotary Gurd";
            inv1.Quantity = 10;
            inv1.UnitPrice = .50m;

            inv2.PartNum = "2002";
            inv2.PartDescript = "Blinker Fluid";
            inv2.Quantity = -10;
            inv2.UnitPrice = -14.01m;
            inv2.Quantity = 2;
            inv2.UnitPrice = 1.01m;

            DisplayInvoice();

            void DisplayInvoice()
            {
                Console.WriteLine("\t[INVOICE 1]");
                Console.WriteLine($"Part Num: {inv1.PartNum}\n" +
                                  $"Description: {inv1.PartDescript}\n" +
                                  $"Quantity: {inv1.Quantity}\n" +
                                  $"Unit Price: {inv1.UnitPrice}\n" +
                                  $"Total Price: {inv1.GetInvoiceAmount()}\n");

                Console.WriteLine("\t[INVOICE 2]");
                Console.WriteLine($"Part Num: {inv2.PartNum}\n" +
                                  $"Description: {inv2.PartDescript}\n" +
                                  $"Quantity: {inv2.Quantity}\n" +
                                  $"Unit Price: {inv2.UnitPrice}\n" +
                                  $"Total Price: {inv2.GetInvoiceAmount()}\n");
            }
            

        }
    }
}
