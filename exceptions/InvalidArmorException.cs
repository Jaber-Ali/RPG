using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.exceptions
{
    public class InvalidArmorException : Exception
    {
        //public InvalidArmorException()
        //{
        //    Console.WriteLine("Invalid Armor. You Cannot equip!");

        //}

        public InvalidArmorException(String message) : base(message) { }
    }

}
