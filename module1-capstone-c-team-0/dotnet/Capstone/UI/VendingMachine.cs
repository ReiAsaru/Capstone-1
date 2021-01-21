using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.UI
{
    public class VendingMachine
    {
        public Dictionary<string, VMItem> InventoryList { get; set; } = new Dictionary<string, VMItem>();
        public VendingMachine()
        {
            string fileName = "Inventory.txt";
            try
            {
                using (StreamReader sr = new StreamReader(fileName)) //reads in file name line by line
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineArray = line.Split("|"); //splitting on the |
                        string position = lineArray[0]; //item position eg. A1, A2
                        decimal price = Convert.ToDecimal(lineArray[2]); //converting price to a decimal value from a string
                        VMItem vm = new VMItem(lineArray[1], price, lineArray[3]); //creating an object of type VMItem, passing in values
                        InventoryList.Add(position, vm); //adding the values to the dictionary
                    }
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input");
            }
        }
        public void DisplayItems()
        {
            Console.Write(String.Format("{0,-35}", "Slot Position")); //writing lines to set up a header
            Console.Write(String.Format("{0,20}", "Name Brand"));
            Console.Write(String.Format("{0,30}", "Price \n"));
            foreach (KeyValuePair<string, VMItem> vmi in InventoryList) //looping through each vmitem
            {
                Console.Write(String.Format("{0,-35}", vmi.Key));
                if (vmi.Value.Quantity > 0) //checking if there is an item left to buy in the vending machine
                {
                    Console.Write(String.Format("{0,20}", vmi.Value.NameBrand));
                }
                else Console.Write("{0,20}", "SOLD OUT");
                Console.Write(String.Format("{0,30}", vmi.Value.Price + "\n"));
            }
        }
    }
}
