using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public abstract class GameObject : IRenderable, ICollidable
    {
        public const string CollisionGroupString = "object";//definirano deistvie pri udar
        protected MatrixCoords topLeft;
        public MatrixCoords TopLeft//poziciq
        {
            get
            {
                return new MatrixCoords(topLeft.Row, topLeft.Col);
            }

            protected set
            {
                this.topLeft = new MatrixCoords(value.Row, value.Col);//vra6ta nov obekt za da se zapazi enkapsulaciqta
            }
        }

        protected char[,] body;//risunka na obekta

        public bool IsDestroyed { get; protected set; }//dali obekta e udaren

        protected GameObject(MatrixCoords topLeft, char[,] body)//TODO: string type
        {
            this.TopLeft = topLeft;
            int imageRows = body.GetLength(0);
            int imageCols = body.GetLength(1);
            this.body = this.CopyBodyMatrix(body);
            this.IsDestroyed = false;
        }

        public abstract void Move();//ne6toto koeto pravi sledva6toto dvijenie    //TODO: dali da vra6ta List<GameObject>

        public virtual void RespondToCollision(CollisionData collisionData)//kazva na obekta 4e e udaren i 4e trqbva da reagira
        {
        }
        public virtual bool CanCollideWith(string otherCollisionGroupString) //tova ne mi trqbva
        {
            return GameObject.CollisionGroupString == otherCollisionGroupString;
        }

        public virtual string GetCollisionGroupString()
        {
            return GameObject.CollisionGroupString;
        }

        char[,] CopyBodyMatrix(char[,] matrixToCopy)//vzema tqloto na matrica i go kopira TODO : public
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

        public char[,] GetImage()////vra6ta kak izglejda obekta
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
