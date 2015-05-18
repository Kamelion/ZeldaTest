using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab2Game
{
    abstract class Mover
    {
        private const int MoveInterval = 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;

        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }

        public bool Nearby(Point locationToCheck, int distance)
        {
            if (Math.Abs(location.X - locationToCheck.X) < distance &&
                (Math.Abs(location.Y - locationToCheck.Y) < distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Nearby(Point enemyLoc, Point playerLoc, int distance, Direction direction)
        {
            bool isNearby = false;

            int deltaX = playerLoc.X - enemyLoc.X,
                deltaY = playerLoc.Y - enemyLoc.Y;

            int xDir = 0, yDir = 0;
            if (deltaX > 0)
                xDir = 1;
            else if (deltaX < 0)
                xDir = -1;

            if (deltaY > 0)
                yDir = 1;
            else if (deltaY < 0)
                yDir = -1;

            int distX = Math.Abs(deltaX),
                distY = Math.Abs(deltaY);


            switch (direction)
            {
                case Direction.Up:
                    if (distY <= distance && xDir == 0 && yDir >= 0)
                        isNearby = true;
                    break;
                case Direction.Down:
                    if (distY <= distance && xDir == 0 && yDir <= 0)
                        isNearby = true;
                    break;
                case Direction.Left:
                    if (distX <= distance && yDir == 0 && xDir >= 0)
                        isNearby = true;
                    break;
                case Direction.Right:
                    if (distX <= distance && yDir == 0 && xDir <= 0)
                        isNearby = true;
                    break;
            }
            return isNearby;
        }

        public Point Move(Direction direction, Rectangle boundaries)
        {
            Point newLocation = location;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MoveInterval >= boundaries.Top)
                        newLocation.Y -= MoveInterval;
                    break;
                case Direction.Down:
                    if (newLocation.Y + MoveInterval <= boundaries.Bottom)
                        newLocation.Y += MoveInterval;
                    break;
                case Direction.Left:
                    if (newLocation.X - MoveInterval >= boundaries.Left)
                        newLocation.X -= MoveInterval;
                    break;
                case Direction.Right:
                    if (newLocation.X + MoveInterval <= boundaries.Right)
                        newLocation.X += MoveInterval;
                    break;
                default: break;
            }
            return newLocation;
        }

        public Point Move(Direction direction, Point targetLoc, Rectangle boundaries)
        {
            return targetLoc;
        }
    }
}
