using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Domain._Base;
using EscapeMines.Domain.Board;
using EscapeMines.Domain.Mines;

namespace EscapeMines.Domain.Turtle
{
    public class AddTurtle
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IRepository<Turtle> _turtleRepository;

        public AddTurtle(ITurtleRepository turtleRepository, IBoardRepository boardRepository)
        {
            _turtleRepository = turtleRepository;
            _boardRepository = boardRepository;
        }

        public void Add(TurtleDto turtleDto)
        {
            var board = _boardRepository.searchById(turtleDto.BoardId);

            var turtle = new Turtle(board, turtleDto.Columns, turtleDto.Rows);

            _turtleRepository.Add(turtle);
        }
    }
}
