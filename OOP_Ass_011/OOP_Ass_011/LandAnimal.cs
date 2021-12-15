using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    class LandAnimal : Pet
    {
        public LandAnimal(double prefered_temperature)
        {
            Prefered_temperature = prefered_temperature;
        }

        public override void Run()
        {
            Hunger += 10;
            Thirst += 10;
            Mood += 20;
        }
    }
}
