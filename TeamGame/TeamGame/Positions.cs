
namespace TeamGame
{
    public struct Positions
    {

        private int row;

        private int col;

        public Positions( int col , int row)
        {
            this.row = row;
            this.col = col;
        }


        public int Row
        {
            get { return this.row; }
            set {this.col = value;}
        }

        public int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }


        public override bool Equals(object obj)
        {

            var comparePositionsObj = (Positions)obj;

            return this.row == comparePositionsObj.row && this.col == comparePositionsObj.col;

        }
        public override int GetHashCode()
        {
            return this.Row.GetHashCode() * 7 + this.Col;
        }



    }
}
