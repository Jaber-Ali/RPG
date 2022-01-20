using RPG.attributes;
using RPG.exceptions;
using RPG.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.characters
{
    public abstract class Character
    {
        private string Name { get; set; }
        private int Level { get; set; }

        public PrimaryAttributes primaryAttributes;

        public PrimaryAttributes totalPrimaryAttributes;

        public enum Slot { HEAD, BODY, LEGS, WEAPON }
        public Dictionary<Slot, Item> equipment {get; set; }
        public PrimaryAttributes totalPrimaryAttribute { get; set; }

        public Character(string name)
        {
            Name = name;
            Level = 1;  
            totalPrimaryAttributes = new PrimaryAttributes();
            equipment = new Dictionary<Slot, Item>();
        }
        public int GetLevel()
        {
            return Level;
        }
        public virtual void LevelUp(int levels)
        {
            if (levels <= 0) 
            {
                throw new Exception();
            }
            
            Level += levels;
            CalculateTotalPrimary();
            
        }

        public void CalculateTotalPrimary()
        {
            totalPrimaryAttributes = new PrimaryAttributes();
            totalPrimaryAttributes.addAttributes(primaryAttributes);

            Slot[] slots = (Slot[])Enum.GetValues(typeof(Slot));
            foreach (Slot slot in slots)
            {
                if (slot == Slot.WEAPON)
                {
                    continue;
                }
                if (!equipment.ContainsKey(slot))
                {
                    continue;
                }
                Armor armor = (Armor)equipment[slot];
                totalPrimaryAttributes.addAttributes(armor.Attributes);
            }
        }
        public abstract double CalculateDPS();

        public double CalculateDPS(int attribute)
        {
            double weaponDPS = 1;
            if (equipment.ContainsKey(Slot.WEAPON))
            {
                Weapon weapon = (Weapon)equipment[Slot.WEAPON];
                weaponDPS = weapon.CalculateDPS();
            }
            return weaponDPS * (1 + attribute / 100.0);
        }
        public abstract void TryEquipWeapon(Weapon weapon);
        public string Equip(Weapon weapon)
        {
            if (weapon.GetLevel() > Level)
            {
                throw new InvalidWeaponException("too low to equip this weapon"); //-----
            }
            TryEquipWeapon(weapon);
            equipment[weapon.GetSlot()] = weapon;
            CalculateTotalPrimary();
            return "New weapon equipped!";
        }
        public abstract void TryEquipArmor(Armor armor);
        public string Equip(Armor armor)
        {
            if (armor.GetLevel() > Level)
            {
                throw new InvalidArmorException("too low to equip this armor"); //-------
            }
            TryEquipArmor(armor);
            equipment[armor.GetSlot()] = armor;
            CalculateTotalPrimary();
            return "New Armor equipped!";
        }
        public override string ToString()
        {
            StringBuilder stats = new StringBuilder();
            stats.Append("\nCharacter Name:       ").Append(Name);
            stats.Append("\nCharacter Level:      ").Append(Level);
            stats.Append("\nStrength:             ").Append(totalPrimaryAttributes.Strength);
            stats.Append("\nDexterity:            ").Append(totalPrimaryAttributes.Dexterity);
            stats.Append("\nIntelligence:         ").Append(totalPrimaryAttributes.Intelligence);
            double dps = CalculateDPS();
            stats.Append("\nDPS:                  ").Append(dps);
            return stats.ToString();
        }
    }
}
