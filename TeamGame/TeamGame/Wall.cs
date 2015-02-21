namespace TeamGame
{

    using System;
    using System.Collections.Generic;
    

    public class Wall
    {

        private int WallLenght;

        private ICollection<Brick> bricks;

        public Wall(ICollection<Brick> bricks)
        {
            this.bricks = bricks;

            this.WallLenght = TeamGame.ConsoleWidth * 3;
          

            this.CreatingWall();

        }

        // Creating thirh rows brigs
        private void CreatingWall()
        {

            var count = 0;
            bool isFull = false;

            var lsatWallPositionRow = TeamGame.ConsoleHeight / 2 - 2;

            while (isFull == false)
            {

                if (count == TeamGame.ConsoleWidth)
                {

                   lsatWallPositionRow++;
                    count = 0;
                }


                this.bricks.Add(new Brick(count, lsatWallPositionRow));

                if (this.bricks.Count == WallLenght)
                {
                    isFull = true;
                }

                count++;

            }

        }


    }
}
