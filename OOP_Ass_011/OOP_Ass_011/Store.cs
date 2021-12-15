using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    class Store
    {
        private List<Storeable> store;

        public Store()
        {
            store = new List<Storeable>();
            AddItems();
        }

        public void AddItems()
        {
            Toy ball = new Toy("Ball", 100, 2, 25, new List<string>() {"LandAnimal"});
            Toy laser_pointer = new Toy("Laser Pointer", 200, 4, 50, new List<string>() { "LandAnimal", "UnderWaterAnimal" });
            Toy beach_ball = new Toy("Beach Ball", 100, 2, 25, new List<string>() { "UnderWaterAnimal" });
            Food dryfood = new Food("Dry Food", 10, 2, 5);
            Food canfood = new Food("Canned Food", 20, 1, 15);
            Drink water = new Drink("Water", 10, 15, 5);
            Drink juice = new Drink("Juice", 20, 30, 15);
            Medicine expensivemedicine = new Medicine("Expensive Medicine", 30, 20, 10, 10);
            Medicine cheapermedicine = new Medicine("Cheaper Medicine", 10, 20, 30, 30);
            store.Add(ball);
            store.Add(laser_pointer);
            store.Add(beach_ball);
            store.Add(dryfood);
            store.Add(canfood);
            store.Add(water);
            store.Add(juice);
            store.Add(expensivemedicine);
            store.Add(cheapermedicine);
        }
        public void Display_Items()
        {
            //This method displays every single item in the store with their price. 
            int index = 1;
            foreach (Storeable item in store)
            {
                Console.Write(index++ + ". ");
                item.Display();
            }
            Console.WriteLine(index + ". Exit");
        }
        public Storeable Shop(int index)
        {
            //Returns an item from the store at a certain position.
            return store[index - 1];
        }
        public int Size()
        {
            return store.Count;
        }
    }
}
