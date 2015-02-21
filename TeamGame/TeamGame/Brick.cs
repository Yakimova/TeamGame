namespace TeamGame
{
    using System;
    using System.Collections.Generic;

    public class Brick
    {

        private Positions position;

        public Brick (int col , int row)
        {
            this.position = new Positions(col, row);
        }

        public Positions Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }



    }
}
