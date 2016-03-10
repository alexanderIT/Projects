namespace Game.Common.Enemy
{
    using Game.Common;
    using Game.Common.Player;

    public class Bomb : MovingObject
    {
        public Bomb(MatrixCoords topLeft, char[,] body, MatrixCoords speed) : base(topLeft, body,speed) { }       

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
