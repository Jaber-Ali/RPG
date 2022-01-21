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
        public string Name { get; set; }
        public int Level { get; set; }
        //  attributes are encapsulated into their own classes.
        public PrimaryAttributes primaryAttributes;
        public PrimaryAttributes totalPrimaryAttributes;

        public enum Slot { HEAD, BODY, LEGS, WEAPON }
        public Dictionary<Slot, Item> equipment {get; set; }
      

        public Character(string name)
        {
            Name = name;
            Level = 1;  
            totalPrimaryAttributes = new PrimaryAttributes();
            equipment = new Dictionary<Slot, Item>();
        }
        /// <summary>
        /// returns current level of a Character - used for checking equipment.
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return Level;
        }
        /// <summary>
        ///  just add amount of levels to the counter of this character.
        ///  increasing attributes is inside derived classes, this also updates total primary attributes.
        /// </summary>
        /// <param name="levels"></param>
        public virtual void LevelUp(int levels)
        {
            Level += levels;
            CalculateTotalPrimary();
            
        }
        /// <summary>
        /// method is common for all characters.
        /// It is called any time when base or armor attributes change.
        /// It summarizes values from base primary attributes and equipped armor,
        /// saving into total primary attributes.
        /// To iterate values from dictionary of armor, enum.Values() method is used.
        /// Weapon is skipped when iterating, as it does not have attributes.
        /// </summary>
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
        /// <summary>
        /// The implementations of this method use different primary attributes in calculating dps.
        /// All of them call the method, which just uses the value of that attribute
        /// </summary>
        /// <returns></returns>
        public abstract double CalculateDPS();

        /// <summary>
        /// Using the given attribute value, calculates total dps of the character.
        /// If there is no weapon, dps of "hands" is 1. Total dps is counted.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
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
        /// <summary>
        /// abstract method, that is needed for every type of character.
        /// Each character has his own valid Weapons, and derived methods check
        /// if given weapon can be equipped for current character
        /// </summary>
        /// <param name="weapon"></param>
        public abstract void TryEquipWeapon(Weapon weapon);
         
        /// base equip method, common for any character. It checks level
        /// and calls the method above, that uses different logic for every type
        /// If everything is good, equips the weapon in weapon slot of the character.
        public string Equip(Weapon weapon)
        {
            if (weapon.GetLevel() > Level)
            {
                throw new InvalidWeaponException("too low to equip this weapon"); 
            }
            TryEquipWeapon(weapon);
            equipment[weapon.GetSlot()] = weapon;
            return "New weapon equipped!";
        }
        /// Here same as Weapon check, but for Armor.
        public abstract void TryEquipArmor(Armor armor);

        /// same as Weapon equip, the only change is that there are several
        /// armor slots, and the slot is taken from armor
        public string Equip(Armor armor)
        {
            if (armor.GetLevel() > Level)
            {
                throw new InvalidArmorException("too low to equip this armor"); 
            }
            TryEquipArmor(armor);
            equipment[armor.GetSlot()] = armor;
            CalculateTotalPrimary();
            return "New armor equipped!";
        }
        /// <summary>
        /// Just a method to print the character stats.
        /// sheet display using StringBuilder.
        /// </summary>
        /// <returns></returns>
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
