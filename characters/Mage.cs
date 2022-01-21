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
    public class Mage : Character
    {
        public Mage(string name) : base(name)
        {
            primaryAttributes = new PrimaryAttributes(1, 1, 8);
            CalculateTotalPrimary();
        }
        public override void LevelUp(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                primaryAttributes.addAttributes(new PrimaryAttributes( 1, 1, 5));
            }
            base.LevelUp(levels);
        }


        public override double CalculateDPS()
        {
            int primaryAttribute = totalPrimaryAttributes.Intelligence;
            return base.CalculateDPS(primaryAttribute); 
        }
        public override void TryEquipWeapon(Weapon weapon) 
        {
            if (weapon.weaponType != Weapon.WeaponType.STAFF && weapon.weaponType != Weapon.WeaponType.WAND)
            {
                throw new InvalidWeaponException("Invalid Weapon. You Cannot equip!");
            }
               
        }

        public override void TryEquipArmor(Armor armor)
        {
            if (armor.armorType != Armor.ArmorType.CLOTH)
            {
                throw new InvalidArmorException("Invalid Armor. You Cannot equip!");
            }
        }

    }
}
