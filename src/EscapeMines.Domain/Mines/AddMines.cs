using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;
using EscapeMines.Domain.Exitpoint;

namespace EscapeMines.Domain.Mines
{
    public class AddMines
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IRepository<Mines> _minesRepository;

        public AddMines(IMinesRepository minesRepository, IBoardRepository boardRepository)
        {
            _minesRepository = minesRepository;
            _boardRepository = boardRepository;
        }

        public void Add(MinesDto minesDto)
        {
            var board = _boardRepository.searchById(minesDto.BoardId);

            var mines = new Mines(board, minesDto.Columns, minesDto.Rows);

            _minesRepository.Add(mines);
        }
    }
}
