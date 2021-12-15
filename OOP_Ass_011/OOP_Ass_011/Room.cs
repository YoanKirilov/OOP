using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    class Room 
    {
        private double ambient_temperature;
        private double current_temperature;

        public Room(double ambient_temperature, double current_temperature)
        {
            this.ambient_temperature = ambient_temperature;
            this.current_temperature = current_temperature;
        }
        public double Ambient_temperature
        {
            get { return this.ambient_temperature; }
            set { this.ambient_temperature = value; }
        }
        public double Current_temperature
        {
            get { return this.current_temperature; }
            set { this.current_temperature = value; }
        }
        public void Adjust_Temperature()
        {
            //If the current temperature is more than the ambient temperature, the current will start decreasing, if is not it will start increasing
            if (current_temperature > ambient_temperature) current_temperature -= 0.01;
            else current_temperature += 0.01;
        }
        public void Display_Temperature()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("| Ambient Temperature = {0:0.##}", ambient_temperature);
            Console.WriteLine("| Current Temperature = {0:0.##}" , current_temperature);
            Console.WriteLine("---------------------------------");
        }
    }
}
