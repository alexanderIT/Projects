using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class SpaceBattleMain
    {
        public const int WorldRows = 40;
        public const int WorldCols = 65;

        static void Initialize(Engine engine)
        {
            int startRow = 0;
            int startCol = 0;

            EnemyShip ship = new EnemyShip(new MatrixCoords(startRow, startCol));
            engine.AddObject(ship);
            PlayerAircraft aircraft = new PlayerAircraft(new MatrixCoords(WorldRows - 10, WorldCols / 2));
            engine.AddObject(aircraft);
        }

        static void Main()
        {
            WindowsSettings.Initialize();
            StartScreen.Initialize();
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();

                WindowsSettings.Initialize();
                IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
                IUserInput keyboard = new KeyboardInput();
                Engine gameEngine = new Engine(renderer, keyboard);
                Initialize(gameEngine);
                gameEngine.Run();
            }

        }
    }
}
