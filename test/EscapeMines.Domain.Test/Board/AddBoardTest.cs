using Bogus;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;
using Moq;
using Xunit;

namespace EscapeMines.Domain.Test.Board
{
    public class AddExitpointTest
    {
        private readonly BoardDTO _boardDto;
        private readonly AddBoard _addBoard;
        private readonly Mock<IBoardRepository> _boardRepositoryMock;


        //setup
        public AddExitpointTest()
        {
            //inputs
            var faker = new Faker(); // library that generete random datas

            _boardDto = new BoardDTO()
            {
                Columns = faker.Random.Int(1, 100),
                Rows = faker.Random.Int(1, 100)
            };

            _boardRepositoryMock = new Mock<IBoardRepository>();
            _addBoard = new AddBoard(_boardRepositoryMock.Object);

        }

        [Fact]
        public void ToAddBoard()
        {
            _addBoard.Add(_boardDto);
            _boardRepositoryMock.Verify(v => v.Add(It.Is<Domain.Board.Board>(
                                    c => c.Columns == _boardDto.Columns)));
        }
    }
}
