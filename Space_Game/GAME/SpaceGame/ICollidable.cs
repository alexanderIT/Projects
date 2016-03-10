using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public interface ICollidable
    {
        bool CanCollideWith(string objectType);

        List<MatrixCoords> GetCollisionProfile();

        string GetCollisionGroupString();

        void RespondToCollision(CollisionData collisionData);//mehanizam po koito engina kazva za koliziq na obektite i te
        //kazvat kakvo da se pravi.Pr.IsDestroyed == true
    }
}
