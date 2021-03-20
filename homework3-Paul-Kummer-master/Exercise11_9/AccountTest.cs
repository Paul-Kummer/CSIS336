using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11_9
{
    class AccountTest
    {
        static void Main(string[] args)
        {
            // Basic Account
            Console.WriteLine("[ Regular Account: $1000 ]");
            var basicAcct = new Account(1000);
            Console.WriteLine(basicAcct);

            Console.WriteLine("\n--- Attempt Overdraft --- [ $1001 ]");
            basicAcct.Debit(1001);
            Console.WriteLine(basicAcct);

            Console.WriteLine("\n--- Attempt Negative Deposit --- [ $-10 ]");
            basicAcct.Credit(-10);
            Console.WriteLine(basicAcct);

            Console.WriteLine("\n--- Attempt Valid Credit --- [ $10 ]");
            basicAcct.Credit(10);
            Console.WriteLine(basicAcct);

            Console.WriteLine("\n--- Attempt Valid Debit --- [ $-10 ]");
            basicAcct.Debit(10);
            Console.WriteLine(basicAcct);


            // Savings Account
            Console.WriteLine("\n##########################################");
            Console.WriteLine("[ Saings Account: $500, 3% ]");
            var saveAcct = new Savings(500, .03M);
            Console.WriteLine(saveAcct);

            Console.WriteLine("\n--- Attempt Overdraft --- [ $1001 ]");
            saveAcct.Debit(1001);
            Console.WriteLine(saveAcct);

            Console.WriteLine("\n--- Attempt Negative Deposit --- [ $-10 ]");
            saveAcct.Credit(-10);
            Console.WriteLine(saveAcct);

            Console.WriteLine("\n--- Attempt Valid Credit --- [ $10 ]");
            saveAcct.Credit(10);
            Console.WriteLine(saveAcct);

            Console.WriteLine("\n--- Attempt Valid Debit --- [ $-10 ]");
            saveAcct.Debit(10);
            Console.WriteLine(saveAcct);

            Console.WriteLine("\n--- Change Interest Rate --- [ .10 ]");
            saveAcct.IntRate = .1M;
            Console.WriteLine(saveAcct);

            Console.WriteLine("\n--- Change Interest Rate --- [ -.10 ]");
            saveAcct.IntRate = -.1M;
            Console.WriteLine(saveAcct);

            // Checking Account
            Console.WriteLine("\n##########################################");
            Console.WriteLine("[ Checking Account: $250, $25/transaction ]");
            var checkAcct = new Checking(250, 25.25M);
            Console.WriteLine(checkAcct);

            Console.WriteLine("\n--- Attempt Overdraft --- [ $1001 ]");
            checkAcct.Debit(1001);
            Console.WriteLine(checkAcct);

            Console.WriteLine("\n--- Attempt Negative Deposit --- [ $-10 ]");
            checkAcct.Credit(-10);
            Console.WriteLine(checkAcct);

            Console.WriteLine("\n--- Attempt Valid Credit --- [ $100 ]");
            checkAcct.Credit(100);
            Console.WriteLine(checkAcct);

            Console.WriteLine("\n--- Attempt Valid Debit --- [ $-10 ]");
            checkAcct.Debit(10);
            Console.WriteLine(checkAcct);

            Console.WriteLine("\n--- Change Transaction Fee --- [ 10 ]");
            checkAcct.TransFee = 10M;
            Console.WriteLine(checkAcct);

            Console.WriteLine("\n--- Change Transaction Fee --- [ -10 ]");
            checkAcct.TransFee = -10M;
            Console.WriteLine(checkAcct);

            Console.WriteLine("\n--- Zero Dollar Transaction --- [ 0 ]");
            checkAcct.Debit(0);
            Console.WriteLine(checkAcct);
        }
    }
}
