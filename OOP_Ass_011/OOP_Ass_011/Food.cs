using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    class Food:Storeable
    {
        private int food_uses;
        private int mood;

        public int Mood
        {
            get { return this.mood; }
            set { this.mood = value; }
        }

        public int Food_uses
        {
            get { return this.food_uses; }
            set { this.food_uses = value; }
        }
        public Food(string type, int price, int food_uses, int mood)
        {
            Type = type;
            Price = price;
            this.food_uses = food_uses;
            this.mood = mood;
        }
    }
}
