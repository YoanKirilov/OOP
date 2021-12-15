using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Ass_011
{
    class UnderWaterAnimal : Pet
    {
        public UnderWaterAnimal(double prefered_temperature)
        {
            Prefered_temperature = prefered_temperature;
        }

        public override void Swim()
        {
            Hunger += 10;
            Thirst += 10;
            Mood += 20;
        }
    }
}
