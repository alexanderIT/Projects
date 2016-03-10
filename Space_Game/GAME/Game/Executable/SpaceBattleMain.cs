namespace Game
{
    using System;

    using Game.Common.Enemy;
    using Game.Common;
    using Game.Common.Player;

    public class SpaceBattleMain
    {
        public const int WorldRows = 40;
        public const int WorldCols = 65;

        static void Initialize(Engine engine)
        {
            int startRow = 0;
            int startCol = 0;
            EnemyShip ship = new EnemyShip(new MatrixCoords(startRow, startCol), new MatrixCoords(0,0));
            engine.AddObject(ship);
            for (int i = startCol; i < WorldCols - 4; i++)
            {
                EnemyShipDestructivePart currBlock = new EnemyShipDestructivePart(new MatrixCoords(startRow + 6, i));
                engine.AddObject(currBlock);
            }

            PlayerAircraft aircraft = new PlayerAircraft(new MatrixCoords(WorldRows -10, WorldCols / 2));
            engine.AddObject(aircraft);
        }

        static void Main()
        {
            //Console.BufferHeight = Console.WindowHeight = WorldRows;
            //Console.BufferWidth = Console.WindowWidth = WorldCols;
            //WindowsSettings.Initialize();
            StartScreen.Initialize();
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                
                //WindowsSettings.Initialize();
                IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
                IUserInput keyboard = new KeyboardInput();
                Engine gameEngine = new Engine(renderer, keyboard);
                Initialize(gameEngine);
                gameEngine.Run();    
            }
                      
        }
    }
}
