using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Domain._Base;

namespace EscapeMines.Domain.Mines
{
    public class Mines : Entity
    {
        private Board.Board Board { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }

        public Mines(Board.Board board, int columns, int rows)
        {
            if (board == null)
                throw new ArgumentException($"Value of Board cannot be negative");
            if (columns < 0)
                throw new ArgumentException($"Value of columns cannot be negative");
            if (rows < 0)
                throw new ArgumentException($"Value of rows cannot be negative");

            this.Board = board;
            this.Columns = columns;
            this.Rows = rows;
        }
    }
}
