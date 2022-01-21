using System;
using RPG.characters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.items
{
    public abstract class Item
    {
        public string Name { get;  set; }
        public int ItemLevel { get;  set; }
        public Character.Slot ItemSlot { get; set; }

        public int GetLevel()
        {
            return ItemLevel;
        }

        public Character.Slot GetSlot()
        {
            return ItemSlot;
        }

    }
    
}
