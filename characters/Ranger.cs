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
    public class Ranger : Character
    {
        public Ranger(string name) : base(name)
        {
            primaryAttributes = new PrimaryAttributes(1, 7, 1);
            CalculateTotalPrimary();
        }
        public override void LevelUp(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                primaryAttributes.addAttributes(new PrimaryAttributes(1, 5, 1));
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
            if (weapon.weaponType != Weapon.WeaponType.BOW)
            {
                throw new InvalidWeaponException("");
            }

        }

        public override void TryEquipArmor(Armor armor)
        {
            if (armor.armorType != Armor.ArmorType.LEATHER && armor.armorType != Armor.ArmorType.MAIL)
            {
                throw new InvalidArmorException("");
            }
        }
    }
}
