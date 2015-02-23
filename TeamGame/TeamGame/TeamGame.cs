using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TeamGame
{
    class TeamGame
    {

        internal const int ConsoleHeight = 31;
        internal const int ConsoleWidth = 60;


        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = ConsoleHeight;
            Console.BufferWidth = Console.WindowWidth = ConsoleWidth;

            var TankPosition = ConsoleWidth / 2 - 4;

            var wallOfbricks = new List<Brick>();

            //Generate wall
            var wallGenerator = new Wall(wallOfbricks);

            var firstPlayerTank = new Tank(TankPosition, 0);
            var secondPlayerTank = new Tank(TankPosition, ConsoleHeight);

            var printer = new Printer(wallOfbricks, firstPlayerTank, secondPlayerTank);

            bool endGame = true;

            while (endGame)
            {

                Console.Clear();

                printer.PrintWall();
                printer.PrintTopTanks();

                firstPlayerTank.Destroy();
                secondPlayerTank.Destroy();

                printer.PrintDownTanks();
                printer.PrintBomb();

                AllCollisions(wallOfbricks, firstPlayerTank, secondPlayerTank);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        firstPlayerTank.MoveLeft();
                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        firstPlayerTank.MoveRight();
                    }

                    if (pressedKey.Key == ConsoleKey.A)
                    {
                        secondPlayerTank.MoveLeft();
                    }
                    if (pressedKey.Key == ConsoleKey.D)
                    {
                        secondPlayerTank.MoveRight();
                    }
                }

                Thread.Sleep(200);

            }

        }


        private static void AllCollisions(List<Brick> wall, Tank topTank, Tank dowTank)
        {
            ColisionTankBombAndWall(wall, topTank, dowTank);
            CollisionTopTankBombAndDownTankBomb(topTank, dowTank);
            CollisionTankBombAndTankBody(topTank, dowTank);
        }

        private static void ColisionTankBombAndWall(List<Brick> wall, Tank topTank, Tank dowTank)
        {

            //wall.Contains();
            //TODO:  topTank bomb or dowTank bomb position contains in wall bricks positions. Use method contains
        }

        private static void CollisionTopTankBombAndDownTankBomb(Tank topTank, Tank downTank)
        {

            //use this method topTank.GenerateNewBomb(); for every tank after collision
            //TODO: when topTank bomb postion is equel to downTank bomb position
        }

        private static void CollisionTankBombAndTankBody(Tank topTank, Tank downTank)
        {
            //topTank.Points++;
            //downTank.Points++;
            // TODO: when tank bomb position hit tank body
        }

    }
}
