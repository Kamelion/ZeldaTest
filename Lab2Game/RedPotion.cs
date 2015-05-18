﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab2Game
{
    class RedPotion : Weapon, IPotion
    {
        public RedPotion(Game game, Point location)
            : base(game, location) { }

        private bool used;
        public bool Used { get { return used; } }

        public override string Name
        {
            get { return "Red Potion"; }
        }

        public override void Attack(Direction direction, Random random)
        {
            //Your code goes here
        }
    }
}
