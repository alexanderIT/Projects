namespace Game.Common.Enemy
{
    using Game.Common;

    public class SmallBomb : Bomb
    {
        public new const string CollisionGroupString = "small bomb";

        public SmallBomb(MatrixCoords topLeft, MatrixCoords speed) : base(topLeft, new char[,] { { '*' } },speed) { }

        public override string GetCollisionGroupString()
        {
            return SmallBomb.CollisionGroupString;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "aircraft";
        }
    }
}
