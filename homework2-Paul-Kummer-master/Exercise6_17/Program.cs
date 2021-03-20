using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6_17
{
    class Program
    {
        //Prod1: $2.98
        //Prod2: $4.50
        //Prod3: $9.98

        //App read series of pairs of nums.
        //a. prod qty
        //b. qty sold
        // use switch statement for retail price of each prod
        //     -calc and disp tot retail value of all prod sold.
        // use sentinel controlled loop to determine when done

        static void Main(string[] args)
        {
            bool isNotDone = true;
            decimal prodOneCost = 2.98m, prodTwoCost = 4.50m, prodThreeCost = 9.98m;
            int prodOneQty = 0, prodTwoQty = 0, prodThreeQty = 0;
            decimal prodOneSum = 0m, prodTwoSum = 0m, prodThreeSum = 0m;
            int curProd = 0;
            char userInput;

            do
            {
                Console.WriteLine("\t--- Which product is selected ---\n" +
                    "[(1) product one, (2) product two, (3) product three, (0) Finished]");

                userInput = Console.ReadKey(true).KeyChar;
                if (char.IsDigit(userInput))
                {
                    curProd = int.Parse(userInput.ToString());  //will be product selected
                }

                else
                {
                    curProd = -1; //indicates invalid entry
                }

                switch (curProd)
                {
                    case 0:
                        Console.WriteLine("\n\t* Completed Entering Products *\n\n");
                        isNotDone = false;
                        break;
                    case 1:
                        Console.WriteLine($"\n---> Product One Selected, Cost/Each: {prodOneCost}");
                        AddQty(ref prodOneQty, ref prodOneSum, prodOneCost);
                        break;
                    case 2:
                        Console.WriteLine($"\n---> Product Two Selected, Cost/Each: {prodTwoCost}");
                        AddQty(ref prodTwoQty, ref prodTwoSum, prodTwoCost);
                        break;
                    case 3:
                        Console.WriteLine($"\n---> Product Three Selected, Cost/Each: {prodThreeCost}");
                        AddQty(ref prodThreeQty, ref prodThreeSum, prodThreeCost);
                        break;
                    default:
                        Console.WriteLine("\n! Unrecognized Product Selection, Enter the Number Zero be Finshed !\n");
                        break;
                }
            } while (isNotDone);

            Console.WriteLine("\t\t\t[    SUMMARY    ]\n");
            Console.WriteLine($"{"Product One Qty: ",20}{prodOneQty,6}, {"Total Cost: ",20}{prodOneSum,10:C}");
            Console.WriteLine($"{"Product Two Qty: ",20}{prodTwoQty,6}, {"Total Cost: ",20}{prodTwoSum,10:C}");
            Console.WriteLine($"{"Product Three Qty: ",20}{prodThreeQty,6}, {"Total Cost: ",20}{prodThreeSum,10:C}");
            Console.WriteLine($"\n{"Grand Total Qty: ",20}{prodOneQty + prodTwoQty + prodThreeQty,6}" +
                $", {"Grand Total Cost:",20}{prodOneSum + prodTwoSum + prodThreeSum,10:C}");
        }

        static void AddQty(ref int curProdQty, ref decimal curProdSum, decimal tmpCost)
        {
            int tmpQty;

            Console.Write("\tQuantity: ");
            bool didParse = int.TryParse(Console.ReadLine(), out tmpQty);

            if (didParse)
            {
                curProdQty += tmpQty;
                curProdSum += (tmpQty * tmpCost);
                Console.WriteLine($"\n[{"Current Selection Cost",35}: {tmpQty * tmpCost,-15:C}]");
                Console.WriteLine($"[{"Total Selection Cost",35}: {curProdSum,-15:C}]\n\n");
            }

            else
            {
                Console.WriteLine("\t !!! Incorrect Number, Please only use integers !!!\n");
            }
        }
    }
}
