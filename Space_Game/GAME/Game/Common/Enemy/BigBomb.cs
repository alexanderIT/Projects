namespace Game.Common.Enemy
{
    using Game.Common;

    public class BigBomb : Bomb
    {
        public new const string CollisionGroupString = "big bomb";

        public BigBomb(MatrixCoords topLeft,MatrixCoords speed) : base(topLeft, new char[,] { {'#', '#'},
                                                                                              {'#','#'}},speed) { }                                                                              

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
