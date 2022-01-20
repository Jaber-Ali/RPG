using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.items
{
    public class Weapon : Item
    {
        public enum WeaponType 
        { 
            AXE, 
            BOW, 
            DAGGER, 
            HAMMER, 
            STAFF, 
            SWORD, 
            WAND 
        }
        public int BaseDamage { get; set; }
        public double AttackSpeed { get; set; }

        public WeaponType weaponType { get; set; }
       

        public double CalculateDPS()
        {
            return BaseDamage * AttackSpeed;
        }
    }
}
