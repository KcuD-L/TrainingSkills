using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Player
{
    internal class Hero
    {
        private Weapon weapon;
        private Movement movement;

        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }

        public void Move()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
}
