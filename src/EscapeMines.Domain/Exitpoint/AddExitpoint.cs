using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;

namespace EscapeMines.Domain.Exitpoint
{
    public class AddExitpoint
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IRepository<Exitpoint> _exitpointRepository;

        public AddExitpoint(IExitpointRepository exitpointRepository, IBoardRepository boardRepository)
        {
            _exitpointRepository = exitpointRepository;
            _boardRepository = boardRepository;
        }

        public void Add(ExitpointDto exitpointDto)
        {
            var board = _boardRepository.searchById(exitpointDto.BoardId);

            var exitpoint = new Exitpoint(board, exitpointDto.Columns, exitpointDto.Rows);

            _exitpointRepository.Add(exitpoint);
        }
    }
}
