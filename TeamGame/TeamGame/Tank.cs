namespace TeamGame
{
    public class Tank
    {

        private Positions position;
        private Bomb bomb;
        private bool isTopTank;
        private byte points;

        public Tank(int col, int row)
        {
            this.points = 0;
            this.position = new Positions(col, row);

            this.bomb = new Bomb(col, row);

            this.isTopTank = this.position.Row < TeamGame.ConsoleHeight / 2;
           
        }

        public Positions BombPosition { get { return this.bomb.Position; } }

        public byte Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        public Positions Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public void MoveLeft()
        {
            this.position.Col--;
        }

        public void MoveRight()
        {
            this.position.Col++;
        }

        public void Destroy()
        {

            if (!this.isTopTank)
            {
                if (this.bomb.Position.Row ==  2)
                {
                    this.GenerateNewBomb();
                }
                else
                {
                    this.bomb.MoveDown();
                }
               
            }
            else
            {

                if (this.bomb.Position.Row == TeamGame.ConsoleHeight - 2)
                {
                    this.GenerateNewBomb();
                }
                else
                {
                    this.bomb.MoveUp();
                }
                
            }


        }

        public void GenerateNewBomb()
        {
            this.bomb = new Bomb(this.position.Col, this.position.Row);
        }

    }
}
