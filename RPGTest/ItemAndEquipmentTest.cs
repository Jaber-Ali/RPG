using RPG.attributes;
using RPG.characters;
using RPG.exceptions;
using RPG.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPGTest
{
    public class ItemAndEquipmentTest
    {
        Warrior warrior = new Warrior("name");

        #region Equipe high level weapon/Armor
        [Fact]
        public void TestEquip_highLevelWeapon_ExpectedException()
        {
            //Arrange

            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                ItemLevel = 2,
                ItemSlot = Character.Slot.WEAPON,
                weaponType = Weapon.WeaponType.AXE,
                BaseDamage = 7,
                AttackSpeed = 1.1
            };

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(testAxe));
        }

        [Fact]
        public void TestEquip_HighLevelArmor_ExpectedException()
        {
            //Arrange

            Armor testPateBody = new Armor()
            {
                Name = "Common plate body armor",
                ItemLevel = 2,
                ItemSlot = Character.Slot.BODY,
                armorType = Armor.ArmorType.PLATE,
                Attributes = new PrimaryAttributes() { Strength = 1 }
            };

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(testPateBody));
        }
        #endregion

        [Fact]
        public void TestEquip_WrongWeaponType_ExpectedException()
        {
            //Arrange

            Weapon testBow = new Weapon()
            {
                Name = "Common bow",
                ItemLevel = 1,
                ItemSlot = Character.Slot.WEAPON,
                weaponType = Weapon.WeaponType.BOW,
                BaseDamage = 12,
                AttackSpeed = 0.8
            };

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(testBow));
        }
        [Fact]
        public void TestEquip_ArmorWeaponType_ExpectedException()
        {
            //Arrange

            Armor testClothHead = new Armor()
            {
                Name = "Common cloth head armor",
                ItemLevel = 1,
                ItemSlot = Character.Slot.BODY,
                armorType = Armor.ArmorType.CLOTH,
                Attributes = new PrimaryAttributes() { Intelligence = 5 }
            };

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(testClothHead));
        }

    }
}
