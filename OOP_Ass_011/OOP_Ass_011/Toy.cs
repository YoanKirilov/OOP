using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    class Toy:Storeable
    {
        private int uses;
        private int mood_increase;
        private List<string> usable_by;

        public int Uses
        {
            get { return this.uses; }
            set { this.uses = value; }
        }
        public int Mood_increase
        {
            get { return this.mood_increase; }
            set { this.mood_increase = value; }
        }
        public List<string> Usable_by
        {
            get { return this.usable_by; }
            set { this.usable_by = value; }
        }

        public Toy(string type, int price, int uses, int mood_increase, List<string> usable_by)
        {
            Type = type;
            Price = price;
            this.uses = uses;
            this.mood_increase = mood_increase;
            this.usable_by = usable_by;
        }

        public override void Display_Priceless()
        {
                Console.WriteLine(Type + ": Uses " + uses);
        }

        public override void Display()
        {
            Console.WriteLine(Type + " = " + Price + " Usable by: " + string.Join(", ", Usable_by));
        }
    }
}
