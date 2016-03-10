using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class BigBomb : Bomb
    {
        public new const string CollisionGroupString = "big bomb";

        public BigBomb(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { {'#', '#'},
                                                                                              {'#','#'}}, speed) { }

        public override string GetCollisionGroupString()
        {
            return BigBomb.CollisionGroupString;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "aircraft";
        }
    }
}
