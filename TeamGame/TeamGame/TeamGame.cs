using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TeamGame
{
    class TeamGame
    {

        internal const  int ConsoleHeight = 31;
        internal const  int ConsoleWidth = 60;


        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = ConsoleHeight;
            Console.BufferWidth = Console.WindowWidth = ConsoleWidth;


            var wallOfbricks = new List<Brick>();

            //Generate wall
            var wallGenerator = new Wall(wallOfbricks);

            var firstPlayerTank = new Tank(ConsoleWidth / 2 - 4, 0);
            var secondPlayerTank = new Tank(ConsoleWidth / 2 - 4, ConsoleHeight);

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

                MoveTanks(firstPlayerTank);
                MoveTanks(firstPlayerTank);


                Thread.Sleep(200);

            }


        }

        private static void MoveTanks(Tank player)
        {
            
            player.MoveLeft();
            player.MoveRight();

            // TODO : Must be imblement tanks move. Use console readkey
        }

        private static void AllCollisions(List<Brick> wall, Tank topTank, Tank dowTank)
        {
            ColisionTankBombAndWall(wall, topTank, dowTank);
            CollisionTopTankBombAndDownTankBomb(topTank , dowTank);
            CollisionTankBombAndTankBody(topTank, dowTank);
        }

        private static void ColisionTankBombAndWall(List<Brick> wall, Tank topTank, Tank dowTank)
        {

            //wall.Contains();
            //TODO:  topTank bomb or dowTank bomb position contains in wall bricks positions. Use method contains
        }
 
        private static void CollisionTopTankBombAndDownTankBomb(Tank topTank , Tank downTank )
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
