using System;
using EscapeMines.Domain._Base;

namespace EscapeMines.Domain.Board
{
    public class Board : Entity
    {
        public int Columns { get; set; }
        public int Rows { get; set; }

        public Board(int columns, int rows)
        {
            if (columns < 0)
                throw new ArgumentException($"Value of columns cannot be negative");
            if (rows < 0)
                throw new ArgumentException($"Value of rows cannot be negative");

            this.Columns = columns;
            this.Rows = rows;
        }
    }
}
