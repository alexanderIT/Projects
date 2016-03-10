namespace Game.Common
{
    using System.Collections.Generic;

    public abstract class GameObject : IRenderable,ICollidable
    {
        public const string CollisionGroupString = "object";

        protected MatrixCoords topLeft;
        public MatrixCoords TopLeft//position
        {
            get
            {
                return new MatrixCoords(topLeft.Row, topLeft.Col);
            }

            protected set
            {
                this.topLeft = new MatrixCoords(value.Row, value.Col);//return a new object to keep encapsulation
            }
        }

        protected char[,] body;//draw of object

        public bool IsDestroyed { get; protected set; }//keep if the object is hitted

        protected GameObject(MatrixCoords topLeft, char[,] body)
        {
            this.TopLeft = topLeft;
            int imageRows = body.GetLength(0);
            int imageCols = body.GetLength(1);
            this.body = this.CopyBodyMatrix(body);
            this.IsDestroyed = false;
        }

        public abstract void Move();//do this action on move  

        public virtual void RespondToCollision(CollisionData collisionData)//inform object that is hitted and the object react
        {
        }
        public virtual bool CanCollideWith(string otherCollisionGroupString)
        {
            return GameObject.CollisionGroupString == otherCollisionGroupString;
        }

        public virtual string GetCollisionGroupString()
        {
            return GameObject.CollisionGroupString;
        }

        char[,] CopyBodyMatrix(char[,] matrixToCopy)//take body of matrix and copy it
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);

            char[,] result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = matrixToCopy[row, col];
                }
            }

            return result;
        }

        public MatrixCoords GetTopLeft()
        {
            return this.TopLeft;
        }

        public char[,] GetImage()//return how it looks the object
        {
            return this.CopyBodyMatrix(this.body);
        }

        public virtual List<MatrixCoords> GetCollisionProfile()
        {
            List<MatrixCoords> profile = new List<MatrixCoords>();

            int bodyRows = this.body.GetLength(0);
            int bodyCols = this.body.GetLength(1);

            for (int row = 0; row < bodyRows; row++)
            {
                for (int col = 0; col < bodyCols; col++)
                {
                    profile.Add(new MatrixCoords(row + this.topLeft.Row, col + this.topLeft.Col));
                }
            }

            return profile;
        }

        public virtual IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject>();
        }
    }
}
