using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Data.Context;
using EscapeMines.Domain.Board;
using EscapeMines.Domain.Turtle;

namespace EscapeMines.Data.Repository
{
    public class TurtleRepository : RepositoryBase<Turtle>, ITurtleRepository
    {
        public TurtleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
