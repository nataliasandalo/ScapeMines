using Bogus;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;
using EscapeMines.Domain.Mines;
using EscapeMines.Domain.Test.Builders;
using EscapeMines.Domain.Turtle;
using Moq;
using Xunit;

namespace EscapeMines.Domain.Test.Board
{
    public class AddTurtleTest
    {
        private readonly Mock<IBoardRepository> _boardRepository;
        private readonly Mock<ITurtleRepository> _turtleRepository;
        private readonly AddTurtle _addTurtle;
        private readonly TurtleDto _turtleDto;
        private readonly Domain.Board.Board _board;

        //setup
        public AddTurtleTest()
        {
            _turtleRepository = new Mock<ITurtleRepository>();
            _boardRepository = new Mock<IBoardRepository>();

            _board = BoardBuilder.NewInstance().WithId(45).Build();
            _boardRepository.Setup(r => r.searchById(_board.Id)).Returns(_board);

            var faker = new Faker();

            _turtleDto = new TurtleDto()
            {
                BoardId = _board.Id,
                Columns = faker.Random.Int(1, 100),
                Rows = faker.Random.Int(1, 100)
            };

            _addTurtle = new AddTurtle(_turtleRepository.Object, _boardRepository.Object);
        }

        [Fact]
        public void ToAddExitpoint()
        {
            _addTurtle.Add(_turtleDto);
            _turtleRepository.Verify(v => v.Add(It.Is<Domain.Turtle.Turtle>(
                c => c.Columns == _turtleDto.Columns)));
        }
    }
}
