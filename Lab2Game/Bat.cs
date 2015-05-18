using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab2Game
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location)
            : base(game, location, 6) { }

        public override void Move(Random random)
        {
            //Your code will go here
            if (random.Next(1, 3) == 1)
            {
                location = Move((Direction)random.Next(0, 4), game.Boundaries);
            }
            else
            {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }
            if (NearPlayer())
            {
                game.HitPlayer(2, random);
            }
        }
    }
}
