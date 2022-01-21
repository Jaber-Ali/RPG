using System;
using RPG.attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.items;
using RPG.exceptions;

namespace RPG.characters
{
    public class Rogue : Character
    {
        public Rogue(string name) : base(name)
        {
            primaryAttributes = new PrimaryAttributes(2, 6, 1);
            CalculateTotalPrimary();
        }

        public override void LevelUp(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                primaryAttributes.addAttributes(new PrimaryAttributes(1, 4, 1));
            }
            base.LevelUp(levels);
        }


        public override double CalculateDPS()
        {
            int primaryAttribute = totalPrimaryAttributes.Dexterity;
            return base.CalculateDPS(primaryAttribute);
        }
        public override void TryEquipWeapon(Weapon weapon)
        {
            if (weapon.weaponType != Weapon.WeaponType.DAGGER && weapon.weaponType != Weapon.WeaponType.SWORD)
            {
                throw new InvalidWeaponException("Invalid Weapon. You Cannot equip!");
            }

        }

        public override void TryEquipArmor(Armor armor)
        {
            if (armor.armorType != Armor.ArmorType.LEATHER && armor.armorType != Armor.ArmorType.MAIL)
            {
                throw new InvalidArmorException("Invalid Armor. You Cannot equip!");
            }
        }
    }
}
