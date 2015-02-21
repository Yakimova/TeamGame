namespace TeamGame
{
    public class Bomb
    {

        private Positions position;

        public Bomb(int col, int row)
        {
            this.position = new Positions(col, row);
        }

        public Positions Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public void MoveUp()
        {

            this.position = new Positions(this.position.Col, this.position.Row + 1);
        }

        public void MoveDown()
        {

            this.position = new Positions(this.position.Col, this.position.Row - 1);

        }


    }
}
