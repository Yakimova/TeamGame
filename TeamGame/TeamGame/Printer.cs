namespace TeamGame
{

    using System;
    using System.Collections.Generic;

    public class Printer
    {

        private ICollection<Brick> wall;
        private Tank firstPlayer;
        private Tank secondPlayer;


        public Printer(ICollection<Brick> wall , Tank firstPlayer , Tank secondPlayer)
        {
            this.wall = wall;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public void PrintWall()
        {
            foreach (var brick in this.wall)
            {
                ConsolePrint(brick.Position.Col , brick.Position.Row, "=");
                
            }
        }

        public void PrintTopTanks()
        {
            this.PrintTankOnTopPosition(this.firstPlayer.Position.Col , this.firstPlayer.Position.Row);
            
        }

        public void PrintDownTanks()
        {
            this.PrintTankOnDownPosition(this.secondPlayer.Position.Col, this.secondPlayer.Position.Row);
        }

        public void PrintBomb()
        {
            this.ConsolePrint(this.firstPlayer.BombPosition.Col, this.firstPlayer.BombPosition.Row, "#");
            this.ConsolePrint(this.secondPlayer.BombPosition.Col, this.secondPlayer.BombPosition.Row, "#");

        }


       private void ConsolePrint(int col , int row , string body)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(body);
        }




       private void PrintTankOnTopPosition(int x, int y = 0)
       {
           // the tank is wide 7 character (from x to x+6)
           //the tank is tall 3 characters(from y to y+2)
           Console.SetCursorPosition(x -3, y);
           Console.Write("{|}");
           Console.SetCursorPosition(x, y);
           Console.Write("|");
           Console.SetCursorPosition(x + 1, y);
           Console.Write("{|}");
           Console.SetCursorPosition(x - 3, y + 1);
           Console.WriteLine("{|}|{|}");
           Console.SetCursorPosition(x -1, y + 2);
           Console.WriteLine("(|)");
       }

       private void PrintTankOnDownPosition(int x, int y)
       {
           // the tank is wide 7 character (from x to x+6)
           //the tank is tall 3 characters(from y-2 to y)
           Console.SetCursorPosition(x -1, y - 3);
           Console.WriteLine("(|)");
           Console.SetCursorPosition(x -3, y - 2);
           Console.WriteLine("{|}|{|}");
           Console.SetCursorPosition(x - 3, y - 1);
           Console.Write("{|}|{|}");
       }


    }
}
