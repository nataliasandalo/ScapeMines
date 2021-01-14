using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Data.Context;
using EscapeMines.Domain.Board;
using EscapeMines.Domain.Exitpoint;

namespace EscapeMines.Data.Repository
{
    public class ExitpointRepository : RepositoryBase<Exitpoint>, IExitpointRepository
    {
        public ExitpointRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
