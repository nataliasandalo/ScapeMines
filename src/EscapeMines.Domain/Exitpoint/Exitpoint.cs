using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Domain.Board;
using EscapeMines.Domain._Base;

namespace EscapeMines.Domain.Exitpoint
{
    public class Exitpoint : Entity
    {
        public EscapeMines.Domain.Board.Board Board { get; set; }
        public int Dir_Columns { get; set; }
        public int Dir_Rows { get; set; }

        public Exitpoint(EscapeMines.Domain.Board.Board board, int columns, int rows)
        {
            if (board == null)
                throw new ArgumentException($"Value of Board cannot be negative");
            if (columns < 0)
                throw new ArgumentException($"Value of columns cannot be negative");
            if (rows < 0)
                throw new ArgumentException($"Value of rows cannot be negative");

            this.Board = board;
            this.Dir_Columns = columns;
            this.Dir_Rows = rows;
        }
    }
}
