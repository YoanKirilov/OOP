using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    abstract class Pet
    {
        private int health=100;
        private int mood=100;
        private int hunger=30;
        private int thirst = 30;
        private int feeding = 0;
        private double prefered_temperature;

        public int Health
        {
            get {return this.health;}
            set 
            {if (value > 100)
                    this.health = 100;
                else {this.health = value;}
            }
        }
        public int Mood
        {
            get { return this.mood; }
            set { if (value > 100)
                        this.mood = 100;
                    else { this.mood = value; }
                }
        }
        public int Hunger
        {
            get { return this.hunger; }
            set { if (value < 0) this.hunger = 0; 
                else if (value > 100) this.hunger = 100; 
                else this.hunger = value; }
        }
        public int Thirst
        {
            get { return this.thirst; }
            set
            {
                if (value < 0) this.thirst = 0;
                else if (value > 100) this.thirst = 100;
                else this.thirst = value;
            }
        }
        public double Prefered_temperature
        {
            get { return this.prefered_temperature; }
            set { this.prefered_temperature = value; }
        }
        public int Feeding
        {
            get { return this.feeding; }
            set { this.feeding = value; }
        }

        public void Feed()
        {
            //If feeding is not 0 the pet will eat and its hunger will decrease by the formula
            if (Feeding != 0)
            {
                this.Feeding--;
                Hunger -= (Mood * Hunger) / 100;
            }
        }
        public void Display_Stat()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("| Pet Type = " + this.GetType().Name);
            Console.WriteLine("| Health = " + health);
            Console.WriteLine("| Hunger = " + hunger);
            Console.WriteLine("| Thirst = " + thirst);
            Console.WriteLine("| Mood = " + mood);
            Console.WriteLine("| Prefered temperature = " + prefered_temperature);
            Console.WriteLine("---------------------------------");
        }
        public virtual void Run()
        {

        }

        public virtual void Swim()
        {

        }
    }
}
