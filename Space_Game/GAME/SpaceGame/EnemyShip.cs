using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class EnemyShip : GameObject
    {
        public new const string CollisionGroupString = "enemyShip";

        public EnemyShip(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { ' ',' ',' ',' ',' ',' ',' ',' ','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_',' ',' ',' ',' ',' ',' ',' ',' '},
                                          { ' ',' ',' ',' ',' ',' ',' ','/',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','\\',' ',' ',' ',' ',' ',' ',' '},
                                          { ' ',' ',' ',' ',' ','_','/',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','\\','_',' ',' ',' ',' ',' '},
                                          { ' ',' ','_','_','/',' ','/','/','/','/','/','/','/','/','/','/','/',' ',' ',' ',' ',' ',' ',' ','(',')','(',')','(',')','(',')','(',')','(',')',' ',' ',' ',' ',' ',' ',' ',' ','\\','\\','\\','\\','\\','\\','\\','\\','\\','\\','\\',' ','\\','_','_',' ',' '},
                                          { ' ','/','(',')','(',')','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','(',')','(',')','\\',' '},
                                          { '/','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','\\'}, }) { }

        public override bool CanCollideWith(string otherCollisionGroupString)// s kogo moga da se sblaskam
        {
            return otherCollisionGroupString == "shot";
        }

        public override void RespondToCollision(CollisionData collisionData)//kakvo pravq kato se sblaskam
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return EnemyShip.CollisionGroupString;
        }

        public override void Move()// TODO: da vra6ta prazen spisak
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            int randomSmallBomb = RandomGenerator.Generator.Next(0, 200);
            int randomBigBomb = RandomGenerator.Generator.Next(0, 100);
            int randomPositionSmallBomb = RandomGenerator.Generator.Next(0, 65);
            int randomPositionBigBomb = RandomGenerator.Generator.Next(0, 65);
            if (randomSmallBomb % 10 == 0 && randomSmallBomb % 2 == 0)
            {
                producedObjects.Add(new SmallBomb(new MatrixCoords(this.TopLeft.Row + 6, randomPositionSmallBomb), new MatrixCoords(1, 0)));
            }
            if (randomSmallBomb % 3 == 0 && randomSmallBomb % 5 == 0)
            {
                producedObjects.Add(new BigBomb(new MatrixCoords(this.TopLeft.Row + 6, randomPositionBigBomb), new MatrixCoords(1, 0)));
            }
            return producedObjects;
        }
    }
}
