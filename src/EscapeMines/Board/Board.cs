using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;

namespace EscapeMines.Board
{
    public class Board
    {
        private readonly AddBoard _addBoard;
        private readonly IRepository<Board> _boardRepositorio;

        public Board(AddBoard addBoard, IRepository<Board> boardRepository)
        {
            _addBoard = addBoard;
            _boardRepositorio = boardRepository;
        }

        public void Add(BoardDTO board)
        {
            _addBoard.Add(board);
        }
    }
}
