using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.UI
{
    public class AuditReport
    {
        public void FeedMoneyLog(int feedMoney, decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter("Log.txt", true))
            {
                sw.WriteLine(DateTime.Now + " Feed Money: $" + feedMoney + " Current Balance: $" + currentBalance);
                //sw.Write("Feed Money" + feedMoney + currentBalance);
            }
        }
        public void PurchaseLog(string name, string slot, decimal price, decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter("Log.txt", true))
            {
                sw.WriteLine(DateTime.Now + " " + name + " Slot Number: " + slot + " Product Price: $" +  price + " Remaining Balance: $" + currentBalance);
                //sw.Write(name + slot + price + currentBalance);
            }
        }
        public void TransactionLog(decimal change, decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter("Log.txt", true))
            {
                sw.WriteLine(DateTime.Now + " Give Change: $" + change.ToString() + " Final Balance: $" + currentBalance);
                //sw.Write(change + currentBalance);
            }
        }
        public AuditReport()
        {
            using (StreamWriter sw = new StreamWriter("Log.txt", true))
            {
                sw.WriteLine(DateTime.Now + " Vending Machine Booted Up ");
                //sw.Write("Vending Machine Booted Up ");
            }
        }
    }
}
