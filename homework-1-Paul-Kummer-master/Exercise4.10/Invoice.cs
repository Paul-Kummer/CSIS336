using System;

namespace exercise4._10
{
    class Invoice
    {
        private int quantity = 0;
        private decimal unitPrice = 0m;
        public string PartNum { get; set; }
        public string PartDescript { get; set; }

        public Invoice(string partNum, string partDescript, int tmpQuantity, decimal tmpPrice)
        {
            PartNum = partNum;
            PartDescript = partDescript;
            Quantity = tmpQuantity; // doesn't allow negative numbers
            UnitPrice = tmpPrice; // doesn't allow negative numbers
        }


        // returns total invoice amount
        public string GetInvoiceAmount()
        {
            decimal totalPrice = UnitPrice * Quantity;
            return $"{totalPrice:C}";
        }

        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                if (value >= 0.0m)
                {
                    unitPrice = value;
                }

                else
                {
                    Console.WriteLine("\nValue must be a Positive Decimal\n");
                }
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                if (value >= 0)
                {
                    quantity = value;
                }

                else
                {
                    Console.WriteLine("\nValue must be a Positive Integer\n"); ;
                }
            }
        }
    }

}
