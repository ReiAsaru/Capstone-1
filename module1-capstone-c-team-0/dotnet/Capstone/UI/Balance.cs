using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI
{
    public class Balance
    {
        public decimal CurrentBalance { get; private set; } = 0m;
        public decimal TotalPurchases { get; private set; } = 0m;
        public int Quarter { get; private set; } = 0;
        public int Nickel { get; private set; } = 0;
        public int Dime { get; private set; } = 0;
        public decimal TotalChange { get; private set; }
        decimal totalChange = 0;
        public Balance()
        {
            TotalChange = totalChange;
        }
        public decimal Deposit(int amountDeposited) //customer deposits money
        {
            if (amountDeposited > 0)
            {
                CurrentBalance += amountDeposited;              
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            return CurrentBalance;
        }
        public decimal Purchase(decimal itemCost)
        {
            CurrentBalance -= itemCost;
            TotalPurchases += itemCost;
            return CurrentBalance;
        }
        public decimal MakeChange(decimal sumOfPurchases)
        {
            while (CurrentBalance >= 0.25m)
            {
                CurrentBalance -= 0.25m;
                Quarter++;
            }
            while (CurrentBalance >= 0.1m)
            {
                CurrentBalance -= 0.1m;
                Dime++;
            }
            while (CurrentBalance >= 0.05m)
            {
                CurrentBalance -= 0.05m;
                Nickel++;
            }
            totalChange = (Quarter * 0.25m) + (Dime * 0.1m) + (Nickel * 0.05m);
            Console.WriteLine("Change Due: {0} Quarter(s) {1} Dime(s) {2} Nickel(s)", Quarter, Dime, Nickel);
            Console.WriteLine("Current balance: $" + CurrentBalance);
            return totalChange;
        }
    }
}
