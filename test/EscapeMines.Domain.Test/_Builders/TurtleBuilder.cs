using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Domain;

namespace EscapeMines.Domain.Test.Builders
{
    // I chose to build this class to minimize the number of instances being created in the tests
    public class TurtleBuilder
    {
        protected Domain.Board.Board Board;
        protected int _id;
        protected int _columns;
        protected int _rows;

        public static TurtleBuilder NewInstance()
        {
            return new TurtleBuilder();
        }

        public TurtleBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public TurtleBuilder WithColumns(int columns)
        {
            _columns = columns;
            return this;
        }

        public TurtleBuilder WithRows(int rows)
        {
            _rows = rows;
            return this;
        }

        public Domain.Turtle.Turtle Build()
        {
            var board = new Domain.Turtle.Turtle(Board, _columns, _rows);

            if (_id > -1)
            {
                var propertyInfo = board.GetType().GetProperty("Id");
                propertyInfo.SetValue(board, Convert.ChangeType(_id, propertyInfo.PropertyType), null);
            }


            return board;
        }
    }
}
