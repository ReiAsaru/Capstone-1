using Capstone.UI;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Capstone
{
    class Program
    {
        private const string MAIN_MENU_OPTION_DISPLAY_ITEMS = "Display Vending Machine Items";
    	private const string MAIN_MENU_OPTION_PURCHASE = "Purchase";
	    private readonly string[] MAIN_MENU_OPTIONS = { MAIN_MENU_OPTION_DISPLAY_ITEMS, MAIN_MENU_OPTION_PURCHASE }; //const has to be known at compile time, the array initializer is not const in C#
        private VendingMachine vm = null;
        private readonly IBasicUserInterface ui = new MenuDrivenCLI();
        private const string Feed_Money = "Feed Money";
        private const string Select_Product = "Select Product";
        private const string Finish_Transaction = "Finish Transaction";
        string[] Purchase_Menu_Options = {Feed_Money, Select_Product, Finish_Transaction};
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            AuditReport report = new AuditReport();
            vm = new VendingMachine();
            decimal sumOfPurchases = 0;
            Balance balance = new Balance(); //creating balance object
            while (true)
            {
                string selection = (string)ui.PromptForSelection(MAIN_MENU_OPTIONS);
                if (selection==MAIN_MENU_OPTION_DISPLAY_ITEMS)
                {
                    vm.DisplayItems();
                }
                else if (selection==MAIN_MENU_OPTION_PURCHASE)
                {                  
                    Console.WriteLine("Balance: $" + balance.CurrentBalance); //telling what the customer balance is
                    selection = (string)ui.PromptForSelection(Purchase_Menu_Options);
                    if (selection == Feed_Money)
                    {
                        HandleFeed(report, balance);
                    }
                    if (selection == Select_Product)
                    {
                        try
                        {
                            vm.DisplayItems();
                            string userSelection = Console.ReadLine();  // getting user input for the item position               
                            VMItem vmi = vm.InventoryList[userSelection.ToUpper()]; //creating the object VMItem, given the key from the user selection                   
                            if (balance.CurrentBalance >= vmi.Price && vmi.Quantity > 0) //checking if the customer is able to purchase
                            {
                                vmi.Purchase(); //purchasing the item from the vending machine
                                balance.Purchase(vmi.Price);
                                sumOfPurchases += vmi.Price;
                                report.PurchaseLog(vmi.NameBrand, userSelection.ToUpper(), vmi.Price, balance.CurrentBalance);                           
                                Console.WriteLine("Your new balance is: $" + balance.CurrentBalance);
                            }
                            else if (balance.CurrentBalance >= vmi.Price && vmi.Quantity <= 0)
                            {
                                Console.WriteLine("Item is sold out, please make another selection.");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds! Please deposit more money.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Input");
                        }
                    }
                    if (selection == Finish_Transaction)
                    {
                        balance.MakeChange(sumOfPurchases);
                        report.TransactionLog(balance.TotalChange, balance.CurrentBalance);
                        break;
                    }        
                }
            }
        }

        private void HandleFeed(AuditReport report, Balance balance)
        {
            try
            {
                int amountToDeposit;
                Console.WriteLine("How much do you wish to deposit? (Whole dollar amounts only.)");
                amountToDeposit = Int32.Parse(Console.ReadLine());
                balance.Deposit(amountToDeposit);
                report.FeedMoneyLog(amountToDeposit, balance.CurrentBalance);
                Console.WriteLine("Your new balance is: $" + balance.CurrentBalance);
            }
            catch
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}
