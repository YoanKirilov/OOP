using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    abstract class Storeable
    {
        private int price;
        private string type;

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public virtual void Display()
        {
            Console.WriteLine(type + " = " + Price);
        }

        public virtual void Display_Priceless()
        {
                Console.WriteLine(type);
        }
    }
}
