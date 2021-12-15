using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    class Medicine:Storeable
    {
        private int health;
        private int hunger;
        private int thirst;

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
        public int Hunger
        {
            get { return this.hunger; }
            set { this.hunger = value; }
        }
        public int Thirst
        {
            get { return this.thirst; }
            set { this.thirst = value; }
        }

        public Medicine(string type, int price, int health, int hunger, int thirst)
        {
            Type = type;
            Price = price;
            this.health = health;
            this.hunger = hunger;
            this.thirst = thirst;
        }
    }
}
