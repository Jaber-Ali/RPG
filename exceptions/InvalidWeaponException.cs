using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.exceptions
{
    public class InvalidWeaponException : Exception
    {
        //public InvalidWeaponException()
        //{
        //     Console.WriteLine("Invalid Weapon. You Cannot equip!");
        //}
        public InvalidWeaponException(String message) : base(message) { }
    }

}
