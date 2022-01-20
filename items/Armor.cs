using System;
using RPG.attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.items
{
    public class Armor : Item
    {
        public enum ArmorType 
        { 
            CLOTH, 
            LEATHER, 
            MAIL, 
            PLATE 
        }

        public ArmorType armorType { get; set; }
        public PrimaryAttributes Attributes { get; set; }
    }
}
