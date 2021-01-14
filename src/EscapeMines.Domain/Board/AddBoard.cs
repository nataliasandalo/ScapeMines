namespace EscapeMines.Domain.Board
{
    public class AddBoard
    {
        private readonly IBoardRepository _boardRepository;

        public AddBoard(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public void Add(BoardDTO boardDto)
        {
            var board = new Domain.Board.Board(boardDto.Columns, boardDto.Rows);

            _boardRepository.Add(board);
        }
    }
}