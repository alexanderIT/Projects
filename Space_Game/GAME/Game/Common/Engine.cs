namespace Game.Common
{
    using System.Collections.Generic;

    using Game.Common.Player;

    public class Engine
    {
        IRenderer renderer;
        IUserInput userInterface;//give access to the controls
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        protected PlayerAircraft aircraft;

        public Engine(IRenderer renderer, IUserInput userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is PlayerAircraft)
                {
                    AddRacket(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void RemoveRacket()
        {
            this.staticObjects.RemoveAll(obj => obj is PlayerAircraft);
            this.allObjects.RemoveAll(obj => obj is PlayerAircraft);
        }

        private void AddRacket(GameObject obj)
        {
            RemoveRacket();
            this.aircraft = obj as PlayerAircraft;
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerAircraftLeft()
        {
            this.aircraft.MoveLeft();
        }

        public virtual void MovePlayerAircraftRight()
        {
            this.aircraft.MoveRight();
        }

        public virtual void AircraftShoot()
        {
            this.aircraft.Fire();
        }

        public void ConectController()
        {
            userInterface.OnLeftPressed += (sender, eventInfo) =>
            {
                this.MovePlayerAircraftLeft();
            };

            userInterface.OnRightPressed += (sender, eventInfo) =>
            {
                this.MovePlayerAircraftRight();
            };

            userInterface.OnActionPressed += (sender, eventInfo) =>
            {
                this.AircraftShoot();
            };
        }

        public virtual void Run()
        {
            ConectController();
            while (true)
            {
                this.renderer.RenderAll();//draw frame

                System.Threading.Thread.Sleep(100);//wait 0.5sec

                this.userInterface.ProcessInput();//check if is pressed arrow,space and if is do the appropriate job

                this.renderer.ClearQueue();//clear buffer

                foreach (var obj in this.allObjects)
                {
                    obj.Move();//move the object
                    this.renderer.EnqueueForRendering(obj);//draw the object
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);
                List<GameObject> producedObjects = new List<GameObject>();//check if it has produced objects
                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);//delete murdered objects
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)//add producuded objects                {
                    this.AddObject(obj);
            }
        }
    }
}

