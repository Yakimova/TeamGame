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
            var secondPlayerTank = new Tank(TankPosition, ConsoleHeight - 1);

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

                TanksMoving(firstPlayerTank, secondPlayerTank);

                Thread.Sleep(200);
                

            }

        }

        private static void TanksMoving(Tank firstPlayerTank, Tank secondPlayerTank)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    secondPlayerTank.MoveLeft();
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    secondPlayerTank.MoveRight();
                }

                if (pressedKey.Key == ConsoleKey.A)
                {
                    firstPlayerTank.MoveLeft();
                }
                if (pressedKey.Key == ConsoleKey.D)
                {
                    firstPlayerTank.MoveRight();
                }
            }
        }


        private static void AllCollisions(List<Brick> wall, Tank topTank, Tank dowTank)
        {
            ColisionTankBombAndWall(wall, topTank);
            ColisionTankBombAndWall(wall, dowTank);
            CollisionTopTankBombAndDownTankBomb(topTank, dowTank);
            
            CollisionTopTankBombAndDownTankBody(topTank, dowTank);
            CollisionDownTankBombAndTopTankBody(dowTank, topTank);
        }

        private static void ColisionTankBombAndWall(List<Brick> wall, Tank tank)
        {

            if (wall.Any(x => x.Position.Equals(tank.BombPosition)))
            {
                var brikToRemove = wall.Where(x => x.Position.Equals(tank.BombPosition)).FirstOrDefault();
                

                wall.Remove(brikToRemove);
               
                tank.GenerateNewBomb();
               
            }
                
        }
        
        private static void CollisionTopTankBombAndDownTankBomb(Tank topTank, Tank downTank)
        {

            if (topTank.BombPosition.Equals( downTank.BombPosition))
            {
                topTank.GenerateNewBomb();
                downTank.GenerateNewBomb();
            }
           
        }

        private static void CollisionDownTankBombAndTopTankBody(Tank downTank, Tank topTankBody)
        {
            if ((downTank.BombPosition.Row == topTankBody.Position.Row + 2)
                && (downTank.BombPosition.Col >= (topTankBody.Position.Col - 3) && downTank.BombPosition.Col <= (topTankBody.Position.Col + 3)))
            {

                
                downTank.Points++;
                downTank.GenerateNewBomb();
            }
        }

        private static void CollisionTopTankBombAndDownTankBody(Tank topTank, Tank downTankBody)
        {
            if ((topTank.BombPosition.Row == downTankBody.Position.Row - 1)
                && (topTank.BombPosition.Col >= (downTankBody.Position.Col - 3) && topTank.BombPosition.Col <= (downTankBody.Position.Col + 3)))
            {

                
                topTank.Points++;
                topTank.GenerateNewBomb();
                Console.SetCursorPosition(1, 2);
                Console.WriteLine(topTank.Points);
            }
        }

    }
}
