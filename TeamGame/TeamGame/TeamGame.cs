using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamGame
{
    class TeamGame
    {
        struct Brick
        {
            public int x;
            public int y;
            public bool isHit;
        }
        static void Main()
        {
            int consoleHeight = Console.BufferHeight = Console.WindowHeight = 40;
            int consoleWidth = Console.BufferWidth = Console.WindowWidth = 80;
            PrintUpTank(consoleWidth / 2 - 4, 0);
            PrintDownTank(consoleWidth / 2 - 4, consoleHeight - 1);
            List<Brick> bricks = CreatingBricks(consoleWidth, consoleHeight);

            for (int i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].isHit == false)
                {
                    PrintBrick(bricks[i].x, bricks[i].y);
                }
            }

            Console.ReadLine();
        }
        static void PrintUpTank(int x, int y = 0)
        {
            // the tank is wide 7 character (from x to x+6)
            //the tank is tall 3 characters(from y to y+2)
            Console.SetCursorPosition(x, y);
            Console.WriteLine("{|}|{|}");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("{|}|{|}");
            Console.SetCursorPosition(x + 2, y + 2);
            Console.WriteLine("(|)");
        }
        static void PrintDownTank(int x, int y)
        {
            // the tank is wide 7 character (from x to x+6)
            //the tank is tall 3 characters(from y-2 to y)
            Console.SetCursorPosition(x + 2, y - 3);
            Console.WriteLine("(|)");
            Console.SetCursorPosition(x, y - 2);
            Console.WriteLine("{|}|{|}");
            Console.SetCursorPosition(x, y - 1);
            Console.WriteLine("{|}|{|}");
        }
        static List<Brick> CreatingBricks(int consoleWidth, int consoleHeight)
        {
            Random randomGenerator = new Random();

            int linesWithBricks = 3;//can be changed
            int numberOfBricksByLine = 60;//can be changed
            List<Brick> bricks = new List<Brick>();
            for (int i = 0; i < linesWithBricks; i++)
            {
                int lines = randomGenerator.Next(7, consoleHeight - 7);
                for (int j = 0; j < numberOfBricksByLine; j++)
                {
                    Brick newBrick = new Brick();
                    newBrick.x = randomGenerator.Next(4, consoleWidth - 1);
                    newBrick.y = lines;
                    newBrick.isHit = false;
                    bricks.Add(newBrick);
                }
            }
            return bricks;
        }
        static void PrintBrick(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("=");
        }
    }
}
