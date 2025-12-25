using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Player
{
    internal abstract class Weapon
    {
        public abstract void Hit();
    }

    internal class Gun : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Buh");
        }
    }

    internal class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Swwwwish");
        }
    }
}
