using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Player
{
    internal abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    internal class BanditFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new Run();
        }

        public override Weapon CreateWeapon()
        {
            return new Gun();
        }
    }

    internal class SuperKnight : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new Fly();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }

}
