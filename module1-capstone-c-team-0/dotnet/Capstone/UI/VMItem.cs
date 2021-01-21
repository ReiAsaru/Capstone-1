using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Capstone.UI
{
    public class VMItem
    {
        public string NameBrand { get; private set; } //setting properties of items in the vending machine
        public decimal Price { get; }
        public string ItemType { get; }
        public VMItem(string nameBrand, decimal price, string itemType)
        {
            NameBrand = nameBrand;
            Price = price;
            ItemType = itemType;
        }
        public int Quantity {get; private set;} = 5;
        public void Purchase()
        {
            Quantity--;
            ItemSound();
        }
        public void ItemSound()
        {
            if (ItemType == "Chip")
            {
                Console.WriteLine("Crunch Crunch, Yum!");
            }
            else if (ItemType == "Drink")
            {
                Console.WriteLine("Glug Glug, Yum!");
            }
            else if (ItemType == "Candy")
            {
                Console.WriteLine("Munch Munch, Yum!");
            }
            else if (ItemType == "Gum")
            {
                Console.WriteLine("Chew Chew, Yum!");
            }
        }
    }
}
