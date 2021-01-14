using Bogus;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;
using EscapeMines.Domain.Exitpoint;
using EscapeMines.Domain.Test.Builders;
using Moq;
using Xunit;

namespace EscapeMines.Domain.Test.Exitpoint
{
    public class AddExitpointTest
    {
        private readonly BoardDTO _boardDto;
        private readonly Mock<IBoardRepository> _boardRepository;
        private readonly Mock<IExitpointRepository> _exitpointRepository;
        private readonly AddExitpoint _addExitpoint;
        private readonly ExitpointDto _exitpointDto;
        private readonly Domain.Exitpoint.Exitpoint _exitpoint;
        private readonly Domain.Board.Board _board;

        //setup
        public AddExitpointTest()
        {
            _exitpointRepository = new Mock<IExitpointRepository>();
            _boardRepository = new Mock<IBoardRepository>();

            _board = BoardBuilder.NewInstance().WithId(45).Build();
            _boardRepository.Setup(r => r.searchById(_board.Id)).Returns(_board);
            
            var faker = new Faker();

            _exitpointDto = new ExitpointDto()
            {
                BoardId = _board.Id, 
                Columns =  faker.Random.Int(1, 100), 
                Rows = faker.Random.Int(1, 100)
            };

            _addExitpoint = new AddExitpoint(_exitpointRepository.Object, _boardRepository.Object);
        }

        [Fact]
        public void ToAddExitpoint()
        {
            _addExitpoint.Add(_exitpointDto);
            _exitpointRepository.Verify(v => v.Add(It.Is<Domain.Exitpoint.Exitpoint>(
                                    c => c.Dir_Columns == _exitpointDto.Columns)));
        }
    }
}
