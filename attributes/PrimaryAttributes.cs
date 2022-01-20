using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.attributes
{
    public class PrimaryAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public PrimaryAttributes()
        {
            Strength = Dexterity = Intelligence = 0;
        }
        public PrimaryAttributes(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public void addAttributes(PrimaryAttributes attributes)
        {
            Strength += attributes.Strength; 
            Dexterity += attributes.Dexterity;
            Intelligence += attributes.Intelligence;

        }

    }
}
