using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Player
{
    internal abstract class Movement
    {
        public abstract void Move();
    }

    internal class Fly : Movement
    { 
        public override void Move() 
        {
            Console.WriteLine("I fly");
        }
    }

    internal class Run : Movement
    {
        public override void Move()
        {
            Console.WriteLine("I run");
        }
    }

}
