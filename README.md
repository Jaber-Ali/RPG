**RPG**
-
This is a console application for RPG-characters made in C# .NET 5.

**About the application**
-
In the application there is a set of Characters and various Items,
that characters can equip.

Classes of characters are: 
-
. **Mage**

. **Ranger**

. **Rogue**

. **Warrior**

Items
- 
Items consist of Weapons and Armor. Any character can equip one Weapon and 
up to three Armor items, each on different parts of his:
. Body 
. Head 
. Body 
. Legs

Attributes
-
Characters have several types of attributes, which represent different aspects of the character. They are 
represented as Primary attributes. 

Primary attributes:
-
.Strength:

.Dexterity:

.Intelligence:

Equip
-

Armor items have their own primary attributes, and when equipped,
attributes of the character are increased.

Equipped weapon increases damage, that can be dealed by the character.

Character have Level, that can be upped. LevelUp increases primary attributes.

Characters are not able to wear any armor, or take any weapon.
Each class has his own possible set of legal items.
If there is a situation, when character tries to equip incorrect item,
a custom exception is rising.
