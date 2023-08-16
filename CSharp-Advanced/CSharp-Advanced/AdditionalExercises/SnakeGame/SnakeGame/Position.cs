using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public Position(Position position)
        {
            this.Row = position.Row;
            this.Col = position.Col;
        }

        public int Row;
        public int Col;
    }
}
