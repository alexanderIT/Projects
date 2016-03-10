
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Bomb : MovingObject
    {
        public Bomb(MatrixCoords topLeft, char[,] body, MatrixCoords speed) : base(topLeft, body, speed) { }



        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
