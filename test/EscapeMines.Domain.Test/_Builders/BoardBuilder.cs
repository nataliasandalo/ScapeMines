using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Domain;

namespace EscapeMines.Domain.Test.Builders
{
    // I chose to build this class to minimize the number of instances being created in the tests
    public class BoardBuilder
    {
        private int _id;
        private int _columns;
        private int _rows;

        public static BoardBuilder NewInstance()
        {
            return new BoardBuilder();
        }

        public BoardBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public BoardBuilder WithColumns(int columns)
        {
            _columns = columns;
            return this;
        }

        public BoardBuilder WithRows(int rows)
        {
            _rows = rows;
            return this;
        }

        public Domain.Board.Board Build()
        {
            var board = new Domain.Board.Board(_columns, _rows);

            if (_id > -1)
            {
                var propertyInfo = board.GetType().GetProperty("Id");
                propertyInfo.SetValue(board, Convert.ChangeType(_id, propertyInfo.PropertyType), null);
            }


            return board;
        }
    }
}
