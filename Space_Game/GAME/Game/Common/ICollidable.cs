namespace Game.Common
{
    using System.Collections.Generic;

    public interface ICollidable
    {
        bool CanCollideWith(string objectType);

        List<MatrixCoords> GetCollisionProfile();

        string GetCollisionGroupString();
        
        void RespondToCollision(CollisionData collisionData);
    }
}
