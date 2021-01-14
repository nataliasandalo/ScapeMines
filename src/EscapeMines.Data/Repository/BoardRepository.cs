using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Data.Context;
using EscapeMines.Domain.Board;

namespace EscapeMines.Data.Repository
{
    public class BoardRepository : RepositoryBase<Board>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
