
using RPG.attributes;
using RPG.characters;
using System;
using Xunit;

namespace RPGTest
{
    public class CharacterTest
    {
        [Fact]
        public void TestCreate_CheckCharacterLevel_ExpectedLevelOne() /*level1*/
        {
            //Arrange 
            int expected = 1;
            int actual;

            //Act
            Character mage = new Mage("name");
            actual = mage.GetLevel();

            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestLevelUp_CheckGainLevel_ExpectedLevelTwo() /*level 2*/
        {
            //Arrange 
            int expected = 2;
            int actual;

            //Act
            Character mage = new Mage("name");
            mage.LevelUp(1);
            actual = mage.GetLevel();

            //Assert
            Assert.Equal(expected, actual);

        }

        #region Character creation with proper default attributes
        [Fact]
        public void TestCreate_CheckMagePrimaryAttributes_ExpectedDefault() /*Default*/
        {
            //Arrange 
            Character mage = new Mage("name");
            int expectedLevel = 1;
            PrimaryAttributes expectedPrimaryAttributes = new PrimaryAttributes()
            {
                Strength = 1,
                Dexterity = 1,
                Intelligence = 8
            };

            //Act
            int actualLevel = mage.GetLevel();
            int actualStrength = mage.totalPrimaryAttributes.Strength;
            int actualDexterity = mage.totalPrimaryAttributes.Dexterity;
            int actualIntelligence = mage.totalPrimaryAttributes.Intelligence;

            //Assert
            Assert.Equal(expectedLevel, actualLevel);

            Assert.Equal(expectedPrimaryAttributes.Strength, actualStrength);
            Assert.Equal(expectedPrimaryAttributes.Dexterity, actualDexterity);
            Assert.Equal(expectedPrimaryAttributes.Intelligence, actualIntelligence);

        }
        [Fact]
        public void TestCreate_CheckRangerPrimaryAttributes_ExpectedDefault() /*Default*/
        {
            //Arrange 
            Character ranger = new Ranger("name");
            int expectedLevel = 1;
            PrimaryAttributes expectedPrimaryAttributes = new PrimaryAttributes()
            {
                Strength = 1,
                Dexterity = 7,
                Intelligence = 1
            };

            //Act
            int actualLevel = ranger.GetLevel();
            int actualStrength = ranger.totalPrimaryAttributes.Strength;
            int actualDexterity = ranger.totalPrimaryAttributes.Dexterity;
            int actualIntelligence = ranger.totalPrimaryAttributes.Intelligence;

            //Assert
            Assert.Equal(expectedLevel, actualLevel);

            Assert.Equal(expectedPrimaryAttributes.Strength, actualStrength);
            Assert.Equal(expectedPrimaryAttributes.Dexterity, actualDexterity);
            Assert.Equal(expectedPrimaryAttributes.Intelligence, actualIntelligence);

        }
        [Fact]
        public void TestCreate_CheckRoguePrimaryAttributes_ExpectedDefault() /*Default*/
        {
            //Arrange 
            Character rogue = new Rogue("name");
            int expectedLevel = 1;
            PrimaryAttributes expectedPrimaryAttributes = new PrimaryAttributes()
            {
                Strength = 2,
                Dexterity = 6,
                Intelligence = 1
            };

              //Act
            int actualLevel = rogue.GetLevel();
            int actualStrength = rogue.totalPrimaryAttributes.Strength;
            int actualDexterity = rogue.totalPrimaryAttributes.Dexterity;
            int actualIntelligence = rogue.totalPrimaryAttributes.Intelligence;

            //Assert
            Assert.Equal(expectedLevel, actualLevel);

            Assert.Equal(expectedPrimaryAttributes.Strength, actualStrength);
            Assert.Equal(expectedPrimaryAttributes.Dexterity, actualDexterity);
            Assert.Equal(expectedPrimaryAttributes.Intelligence, actualIntelligence);

        }
        [Fact]
        public void TestCreate_CheckWarriorPrimaryAttributes_ExpectedDefault() /*Default*/
        {
            //Arrange 
            Character warrior = new Warrior("name");
            int expectedLevel = 1;
            PrimaryAttributes expectedPrimaryAttributes = new PrimaryAttributes()
            {
                Strength = 5,
                Dexterity = 2,
                Intelligence = 1
            };

            //Act
            int actualLevel = warrior.GetLevel();
            int actualStrength = warrior.totalPrimaryAttributes.Strength;
            int actualDexterity = warrior.totalPrimaryAttributes.Dexterity;
            int actualIntelligence = warrior.totalPrimaryAttributes.Intelligence;

            //Assert
            Assert.Equal(expectedLevel, actualLevel);

            Assert.Equal(expectedPrimaryAttributes.Strength, actualStrength);
            Assert.Equal(expectedPrimaryAttributes.Dexterity, actualDexterity);
            Assert.Equal(expectedPrimaryAttributes.Intelligence, actualIntelligence);
          
        }
        #endregion
        #region Character attributes increased when leveling up.
        [Fact]
        public void TestLevelUp_CheckMagePrimaryAttributes_ExpectedIncreased() 
        {
            //Arrange 
            Character mage = new Mage("name");
            PrimaryAttributes expectedPrimaryAttributes = new PrimaryAttributes()
            {
                Strength = 2,
                Dexterity = 2,
                Intelligence = 13
            };

            //Act
            mage.LevelUp(1);
            int actualStrength = mage.totalPrimaryAttributes.Strength;
            int actualDexterity = mage.totalPrimaryAttributes.Dexterity;
            int actualIntelligence = mage.totalPrimaryAttributes.Intelligence;

            //Assert

            Assert.Equal(expectedPrimaryAttributes.Strength, actualStrength);
            Assert.Equal(expectedPrimaryAttributes.Dexterity, actualDexterity);
            Assert.Equal(expectedPrimaryAttributes.Intelligence, actualIntelligence);

        }
        [Fact]
        public void TestLevelUp_CheckRangerPrimaryAttributes_ExpectedIncreased()
        {
            //Arrange 
            Character ranger = new Ranger("name");
            PrimaryAttributes expectedPrimaryAttributes = new PrimaryAttributes()
            {
                Strength = 2,
                Dexterity = 12,
                Intelligence = 2
            };

            //Act
            ranger.LevelUp(1);
            int actualStrength = ranger.totalPrimaryAttributes.Strength;
            int actualDexterity = ranger.totalPrimaryAttributes.Dexterity;
            int actualIntelligence = ranger.totalPrimaryAttributes.Intelligence;

            //Assert

            Assert.Equal(expectedPrimaryAttributes.Strength, actualStrength);
            Assert.Equal(expectedPrimaryAttributes.Dexterity, actualDexterity);
            Assert.Equal(expectedPrimaryAttributes.Intelligence, actualIntelligence);

        }
        [Fact]
        public void TestLevelUp_CheckRoguePrimaryAttributes_ExpectedIncreased()
        {
            //Arrange 
            Character rogue = new Rogue("name");
            PrimaryAttributes expectedPrimaryAttributes = new PrimaryAttributes()
            {
                Strength = 3,
                Dexterity = 10,
                Intelligence = 2
            };

            //Act
            rogue.LevelUp(1);
            int actualStrength = rogue.totalPrimaryAttributes.Strength;
            int actualDexterity = rogue.totalPrimaryAttributes.Dexterity;
            int actualIntelligence = rogue.totalPrimaryAttributes.Intelligence;

            //Assert

            Assert.Equal(expectedPrimaryAttributes.Strength, actualStrength);
            Assert.Equal(expectedPrimaryAttributes.Dexterity, actualDexterity);
            Assert.Equal(expectedPrimaryAttributes.Intelligence, actualIntelligence);

        }
        [Fact]
        public void TestLevelUp_CheckWarriorPrimaryAttributes_ExpectedIncreased()
        {
            //Arrange 
            Character warrior = new Warrior("name");
            PrimaryAttributes expectedPrimaryAttributes = new PrimaryAttributes()
            {
                Strength = 8,
                Dexterity = 4,
                Intelligence = 2
            };

            //Act
            warrior.LevelUp(1);
            int actualStrength = warrior.totalPrimaryAttributes.Strength;
            int actualDexterity = warrior.totalPrimaryAttributes.Dexterity;
            int actualIntelligence = warrior.totalPrimaryAttributes.Intelligence;

            //Assert

            Assert.Equal(expectedPrimaryAttributes.Strength, actualStrength);
            Assert.Equal(expectedPrimaryAttributes.Dexterity, actualDexterity);
            Assert.Equal(expectedPrimaryAttributes.Intelligence, actualIntelligence);

        }
        #endregion
    }

}
