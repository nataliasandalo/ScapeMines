using System;
using Bogus;

namespace EscapeMines.Domain.Test.Builders
{
    // I chose to build this class to minimize the number of instances being created in the tests
    public class ExitpointBuilder
    {
        protected Domain.Board.Board Board;
        protected int _id;
        protected int _columns;
        protected int _rows;

        public static ExitpointBuilder NewInstance()
        {
            var faker = new Faker();
            var board = BoardBuilder.NewInstance().Build();

            return new ExitpointBuilder
            {
                Board = board,
                _columns = faker.Random.Int(1,100),
                _rows = faker.Random.Int(1, 100),
            };

            return new ExitpointBuilder();
        }

        public ExitpointBuilder WithBoard(Domain.Board.Board Board)
        {
            Board = Board;
            return this;
        }

        public ExitpointBuilder WithColumns(int columns)
        {
            _columns = columns;
            return this;
        }

        public ExitpointBuilder WithRows(int rows)
        {
            _rows = rows;
            return this;
        }

        public Domain.Exitpoint.Exitpoint Build()
        {
            var board = new Domain.Exitpoint.Exitpoint(Board, _columns, _rows);

            if (_id > -1)
            {
                var propertyInfo = board.GetType().GetProperty("Id");
                propertyInfo.SetValue(board, Convert.ChangeType(_id, propertyInfo.PropertyType), null);
            }


            return board;
        }
    }
}
