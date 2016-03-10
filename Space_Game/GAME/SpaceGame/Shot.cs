
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Shot : MovingObject
    {
        public new const string CollisionGroupString = "shot";

        public Shot(MatrixCoords topLeft, MatrixCoords speed) : base(topLeft, new char[,] { { '|' } }, speed) { }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "enemyShip";
        }

        public override string GetCollisionGroupString()
        {
            return Shot.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)//kurshuma iz4ezva
        {
            this.IsDestroyed = false;
        }




    }
}
