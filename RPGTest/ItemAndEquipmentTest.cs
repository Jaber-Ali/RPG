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
        public void TestEquip_HighLevelWeapon_ExpectedException()
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
        #region Equipe wrong Weapon/Armor Type
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
        public void TestEquip_WrongArmorWeaponType_ExpectedException()
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
        #endregion
        #region Equipe Valid Weapon/Armor and return success msg string
        [Fact]
        public void TestEquip_ValidWeapon_ExpectedReturnString()
        {
            //Arrange

            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                ItemLevel = 1,
                ItemSlot = Character.Slot.WEAPON,
                weaponType = Weapon.WeaponType.AXE,
                BaseDamage = 7,
                AttackSpeed = 1.1
            };
            string expected = "New weapon equipped!";

            //Act
            string actual = warrior.Equip(testAxe);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestEquip_ValidArmor_ExpectedReturnString()
        {
            //Arrange

            Armor testPlateBody = new Armor()
            {
                Name = "Common plate body armor",
                ItemLevel = 1,
                ItemSlot = Character.Slot.BODY,
                armorType = Armor.ArmorType.PLATE,
                Attributes = new PrimaryAttributes() { Strength = 1 }
            };
            string expected = "New armor equipped!";

            //Act
            string actual = warrior.Equip(testPlateBody);

            //Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Calculate Damage
        [Fact]
        public void TestCalculateDPS_NoWeapon_ExpectedDPS()
        {
            //Arrange
            warrior.Level = 1;
            double expectedDPS = 1 * (1 + 5.0 / 100);
          
            //Act
            double actual = warrior.CalculateDPS();

            //Assert
            Assert.Equal(expectedDPS, actual);
        }
        [Fact]
        public void TestCalculateDPS_ValidWeapon_ExpectedDPS()
        {
            //Arrange
            Warrior warrior = new Warrior("name");
            warrior.Level = 1;
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                ItemLevel = 1,
                ItemSlot = Character.Slot.WEAPON,
                weaponType = Weapon.WeaponType.AXE,
                BaseDamage = 7,
                AttackSpeed = 1.1
            };
            double expectedDPS = (7 * 1.1) * (1 + 5.0 / 100);

            //Act
            warrior.Equip(testAxe);
            double actual = warrior.CalculateDPS();

            //Assert
            Assert.Equal(expectedDPS, actual);
        }
        [Fact]
        public void TestCalculateDPS_ValidWeaponAndArmor_ExpectedDPS()
        {
            //Arrange
            Character warrior = new Warrior("name");
            warrior.Level = 1;
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                ItemLevel = 1,
                ItemSlot = Character.Slot.WEAPON,
                weaponType = Weapon.WeaponType.AXE,
                BaseDamage = 7,
                AttackSpeed = 1.1
            };
            Armor testPlateBody = new Armor()
            {
                Name = "Common plate body armor",
                ItemLevel = 1,
                ItemSlot = Character.Slot.BODY,
                armorType = Armor.ArmorType.PLATE,
                Attributes = new PrimaryAttributes() { Strength = 1 }
            };
            double expectedDPS = (7 * 1.1) * (1 + (5.0 + 1) / 100);

            //Act
            warrior.Equip(testAxe);
            warrior.Equip(testPlateBody);
            double actual = warrior.CalculateDPS();

            //Assert
            Assert.Equal(expectedDPS, actual);
        }
        #endregion
    }
}
