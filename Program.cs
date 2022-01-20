using RPG.attributes;
using RPG.characters;
using RPG.exceptions;
using RPG.items;
using System;

namespace RPG
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* create some character of any level you want*/
            Warrior warrior = new Warrior("Samurai");
            warrior.LevelUp(1);

            Weapon textAxe = new Weapon()
            {
                Name = "common Axe",
                RequiredLevel = 1,
                ItemSlot = Character.Slot.WEAPON,
                weaponType = Weapon.WeaponType.AXE,
                BaseDamage = 7, AttackSpeed = 1.1 

            };

            Armor testPlateBody = new Armor()
            {
                Name = "Common plate body armor",
                RequiredLevel = 1,
                ItemSlot = Character.Slot.BODY,
                armorType = Armor.ArmorType.PLATE,
                Attributes = new PrimaryAttributes() { Strength = 1 }
            };

            Weapon testBow = new Weapon()
            {
                Name = "Common bow",
                RequiredLevel = 1,
                ItemSlot = Character.Slot.WEAPON,
                weaponType = Weapon.WeaponType.BOW,
                BaseDamage = 12,
                AttackSpeed = 0.8
            };
            Armor testClothHead = new Armor()
            {
                Name = "Common cloth head armor",
                RequiredLevel = 1,
                ItemSlot = Character.Slot.BODY,
                armorType = Armor.ArmorType.CLOTH,
                Attributes = new PrimaryAttributes() { Intelligence = 5 }
            };

            try
            {
                warrior.Equip(textAxe);
                warrior.Equip(testPlateBody);
                warrior.Equip(testBow);
                warrior.Equip(testClothHead); 
            }

            //This will be Exception --- it will show us Exceptions --- InvalidArmorException/InvalidWeaponException in the console-Terminal

            catch (Exception e) when (e is InvalidWeaponException || e is InvalidArmorException)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(warrior);
        }

    
    }
}
