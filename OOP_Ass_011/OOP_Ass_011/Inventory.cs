using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    class Inventory
    {
        private int coins;
        private List<Storeable> inv;

        public Inventory()
        {
            coins = 500;
            inv = new List<Storeable>();
        }

        public int Coins
        {
            get { return this.coins; }
            set { this.coins = value; }
        }

        public void Add_Item(Storeable item)
        {
            inv.Add(item);
        }

        public void Remove_Item(Storeable item)
        {
            inv.Remove(item);
        }

        public void Display()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("| Coins = " + coins);
            Console.WriteLine("| Items in inventory:");
            int index = 1;
            // This foreach cycle is for displaying every storeable item in inventory and with index++ we are adding a number to every single item.
            foreach (Storeable item in inv)
            {
                Console.Write("| " + index++ + ". ");
                item.Display_Priceless();
            }
            Console.WriteLine("---------------------------------");
        }

        public void Display(string type)
        {
            //This method displays every single item from the inventory from a certain type. 
            int index = 1;
            foreach (Storeable item in inv)
            {
                if (item.GetType().Name == type)
                {
                    Console.Write(index++ + ". ");
                    item.Display_Priceless();
                }
            }
        }

        public Storeable Contains(string item)
        {
            //This method checks if there is an item of a certain type in the inventory.
            foreach (Storeable i in inv)
            {
                if (i.GetType().Name == item)
                {
                    return i;
                }
            }
            return null;
        }

        public Storeable Use(int index, string type)
        {
            //This method returns the n-th item of a certain type.
            foreach (Storeable item in inv)
            {
                if (item.GetType().Name == type)
                {
                    index--;
                    if (index == 0)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
    }
}
