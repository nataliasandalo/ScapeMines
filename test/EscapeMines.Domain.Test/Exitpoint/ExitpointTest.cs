using Bogus;
using EscapeMines.Domain.Test.Builders;
using EscapeMines.Domain.Test.Utils;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace EscapeMines.Domain.Test.Exitpoint
{
    public class ExitpointTest 
    {
        private readonly ITestOutputHelper _output;

        private readonly int _columns;
        private readonly int _rows;

        //setup
        public ExitpointTest(ITestOutputHelper output)
        {
            _output = output;

            //inputs
            var faker = new Faker(); // library that generete random datas

            _columns = 3;
            _rows = 2;
        }

        //Create a board with the values of Id, columns and rows

        [Fact(DisplayName = "CreateBoard")]
        public void CreateBoard()
        {
            var expectedBoard = new
            {
                Columns = _columns,
                Rows = _rows
            };            
            
            var board = new Domain.Board.Board(expectedBoard.Columns, expectedBoard.Rows);

            expectedBoard.ToExpectedObject().ShouldMatch(board);

        }

        //Valid if the parameter Columns is nevative

        [Theory]
        [InlineData(-2)]
        public void Board_NegativeValidationColumns(int columnsInvalid)
        {
            string messageError = "Value of columns cannot be negative";
            
            Assert.Throws<ArgumentException>(() => BoardBuilder.NewInstance().WithColumns(columnsInvalid).Build()).ValidMessage(messageError);
        }

        //Valid if the parameter Rows is nevative

        [Theory]
        [InlineData(-2)]
        public void Board_NegativeValidationRows(int rowsInvalid)
        {
            string messageError = "Value of rows cannot be negative";

            Assert.Throws<ArgumentException>(() => BoardBuilder.NewInstance().WithRows(rowsInvalid).Build()).ValidMessage(messageError);
        }        
    }
}
