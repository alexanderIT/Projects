namespace Game.Common.Player
{
    using System.Collections.Generic;

    using Game.Common;
    using Game.Common.Enemy;

    public class PlayerAircraft : GameObject
    {
        public new const string CollisionGroupString = "aircraft";
        private bool shotFired = false;

        public PlayerAircraft(MatrixCoords topLeft)
             : base(topLeft, new char[,] {  {' ',' ',' ',' ',' ',' ','/','\\',' ',' ',' ',' ',' '},
                                            {' ',' ',' ',' ',' ','|','|','|','|',' ',' ',' ',' '},
                                            {' ',' ',' ',' ',' ','|','|','|','|',' ',' ',' ',' '},
                                            {' ','/','-','-','-',' ', '/', '\\','-','-','-','\\',' '},
                                            {'/','_','_','_','_',' ', '|', '|','_','_', '_','_','\\'},
                                            {' ',' ',' ',' ',' ','|', '|', '|','|', ' ', ' ',' ',' '},
                                            {' ',' ',' ',' ',' ','|', '|', '|','|', ' ', ' ',' ',' '},
                                            {' ',' ',' ',' ','/', '/', '|', '|', '\\', '\\', ' ',' ',' '},
                                            {' ',' ',' ','/','_', '_', '/', '\\', '_', '_', '\\',' ',' '}, }) { }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "big bomb" || otherCollisionGroupString == "small bomb";
        }

        public override string GetCollisionGroupString()
        {
            return PlayerAircraft.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public void MoveLeft()
        {
            if (this.TopLeft.Col > 0)
            {
                this.topLeft.Col--;
                return;
            }
            
        }

        public void MoveRight()
        {
            if (this.TopLeft.Col <= SpaceBattleMain.WorldCols - 14)
            {
                this.topLeft.Col++;    
            }           
        }

        public override void Move()
        {
        }

        public void Shoot()
        {
            this.ProduceObjects();
        }
        public void Fire()
        {
            this.shotFired = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            if (shotFired)
            {
                producedObjects.Add(new Shot(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col + 6),new MatrixCoords(-1,0)));
                shotFired = false;
            }
            return producedObjects;
        }
    }
}
