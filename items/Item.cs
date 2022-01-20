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
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Character.Slot ItemSlot { get; set; }

        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            this.Name = name;
        }
        public int GetLevel()
        {
            return RequiredLevel;
        }
        public void SetLevel(int requiredLevel)
        {
            this.RequiredLevel = requiredLevel;
        }

        public Character.Slot GetSlot()
        {
            return ItemSlot;
        }

    }
    
}
