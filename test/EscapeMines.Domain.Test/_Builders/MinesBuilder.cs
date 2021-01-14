using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Domain;

namespace EscapeMines.Domain.Test.Builders
{
    // I chose to build this class to minimize the number of instances being created in the tests
    public class MinesBuilder
    {
        protected Domain.Board.Board Board;
        protected int _id;
        protected int _columns;
        protected int _rows;

        public static MinesBuilder NewInstance()
        {
            return new MinesBuilder();
        }

        public MinesBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public MinesBuilder WithColumns(int columns)
        {
            _columns = columns;
            return this;
        }

        public MinesBuilder WithRows(int rows)
        {
            _rows = rows;
            return this;
        }

        public Domain.Mines.Mines Build()
        {
            var board = new Domain.Mines.Mines(Board, _columns, _rows);

            if (_id > -1)
            {
                var propertyInfo = board.GetType().GetProperty("Id");
                propertyInfo.SetValue(board, Convert.ChangeType(_id, propertyInfo.PropertyType), null);
            }


            return board;
        }
    }
}
