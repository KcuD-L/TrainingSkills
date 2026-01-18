using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Learning.Cars
{
    internal class Bus : Vehicle
    {
        public override void Move() => Console.WriteLine("Автобус едет"); 
    }

    internal class Electrocar : Vehicle
    {
        public override void Move() => Console.WriteLine("Едет бесшумно"); 
    }

    internal class Horse : IMovable
    {
        public void Move() => Console.WriteLine("Скачет голопом");
    }
}
