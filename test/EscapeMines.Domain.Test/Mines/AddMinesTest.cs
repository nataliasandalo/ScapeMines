using Bogus;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;
using EscapeMines.Domain.Exitpoint;
using EscapeMines.Domain.Mines;
using EscapeMines.Domain.Test.Builders;
using Moq;
using Xunit;

namespace EscapeMines.Domain.Test.Mines
{
    public class AddMinesTest
    {
        private readonly Mock<IBoardRepository> _boardRepository;
        private readonly Mock<IMinesRepository> _minesRepository;
        private readonly AddMines _addMines;
        private readonly MinesDto _MinesDto;
        private readonly Domain.Board.Board _board;

        //setup
        public AddMinesTest()
        {
            _minesRepository = new Mock<IMinesRepository>();
            _boardRepository = new Mock<IBoardRepository>();

            _board = BoardBuilder.NewInstance().WithId(45).Build();
            _boardRepository.Setup(r => r.searchById(_board.Id)).Returns(_board);

            var faker = new Faker();

            _MinesDto = new MinesDto()
            {
                BoardId = _board.Id,
                Columns = faker.Random.Int(1, 100),
                Rows = faker.Random.Int(1, 100)
            };

            _addMines = new AddMines(_minesRepository.Object, _boardRepository.Object);
        }

        [Fact]
        public void ToAddExitpoint()
        {
            _addMines.Add(_MinesDto);
            _minesRepository.Verify(v => v.Add(It.Is<Domain.Mines.Mines>(
                c => c.Columns == _MinesDto.Columns)));
        }
    }
}
