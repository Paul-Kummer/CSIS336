using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11_9
{
    class Account
    {
        private decimal balance;

        public enum Transaction { Failed, Complete, Pending, None}

        public Account(decimal initBal = 0)
        {
            Balance = initBal;
        }

        public decimal Balance 
        { 
            get
            {
                return balance;
            }

            private set
            {
                if (value >= 0M)
                {
                    balance = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value
                        , $"Amount: {value}, Balance must be greater than or equal to zero");
                }
            }
        }

        public virtual bool Debit(decimal amount) // cannot exceed balance otherwise bal won't change
        {
            var debitStatus = Transaction.None; 

            if (amount >= Balance && amount >= 0)
            {
                Console.WriteLine("Debit amount exceeded accounts balance");
                debitStatus = Transaction.Failed;
            }

            else
            {
                Balance -= amount;
                debitStatus = Transaction.Complete;
            }

            return debitStatus == Transaction.Complete;
        }

        public virtual bool Credit(decimal amount)
        {
            var creditStatus = Transaction.None;

            if (amount >= 0)
            {
                Balance += amount;
                creditStatus = Transaction.Complete;
            }

            else
            {
                Console.WriteLine("Credit amount cannot be negative");
                creditStatus = Transaction.Failed;
            }

            return creditStatus == Transaction.Complete;
        }

        public override string ToString()
        {
            return $"Account Balance: {Balance:C}";
        }
    }

    class Savings : Account
    {
        private decimal intRate;

        public Savings(decimal initBal, decimal initRate) : base(initBal)
        {
            IntRate = initRate;
        }

        public decimal IntRate
        {
            get
            {
                return intRate;
            }

            set
            {
                if (value >= 0M)
                {
                    intRate = value;
                }

                else
                {
                    Console.WriteLine("Intrest rate cannot be a negative value");
                }
            }
        }

        public decimal CalculateInterest() => Balance * IntRate;

        public override string ToString()
        {
            return base.ToString() + $"\nInterest Rate: {IntRate:P}" +
                $"\nTotal Interest: {CalculateInterest():C}";
        }
    }

    class Checking : Account
    {
        private decimal transFee;

        public Checking(decimal initBal, decimal initFee) : base(initBal)
        {
            TransFee = initFee;
        }

        public decimal TransFee 
        {
            get
            {
                return transFee;
            }
            
            set
            {
                if (value >= 0M)
                {
                    transFee = value;
                }

                else
                {
                    Console.WriteLine("Transaction Fee cannot be a negative value");
                }
            }
        }

        public override bool Credit(decimal amount)
        {
            var creditStatus = base.Credit(amount - TransFee) ? Transaction.Complete : Transaction.Failed;

            return creditStatus ==  Transaction.Complete;
        }

        public override bool Debit(decimal amount)
        {
            var debiStatus = base.Debit(amount + TransFee) ? Transaction.Complete : Transaction.Failed;

            return debiStatus == Transaction.Complete;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nTransaction Fee: {TransFee:C}";
        }
    }
}
