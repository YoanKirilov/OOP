using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    class Drink:Storeable
    {
        private int hydration;
        private int mood;

        public int Hydration
        {
            get { return this.hydration; }
            set { this.hydration = value; }
        }
        public int Mood
        {
            get { return this.mood; }
            set { this.mood = value; }
        }
        public Drink(string type, int price, int hydration, int mood)
        {
            Type = type;
            Price = price;
            this.mood = mood;
            this.hydration = hydration;
        }
    }
}
