namespace Game.Common.Enemy
{
    public class EnemyShipDestructivePart : GameObject
    {
        public new const string CollisionGroupString = "destructive part";

        public EnemyShipDestructivePart(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '#' } })
        {

        }

        public override void Move()
        {
            
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "shot";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return EnemyShipDestructivePart.CollisionGroupString;
        }
    }
}
