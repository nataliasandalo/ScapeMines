using System;
using System.Collections.Generic;
using System.Text;
using EscapeMines.Data.Context;
using EscapeMines.Domain.Mines;

namespace EscapeMines.Data.Repository
{
    public class MinesRepository : RepositoryBase<Mines>, IMinesRepository
    {
        public MinesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
