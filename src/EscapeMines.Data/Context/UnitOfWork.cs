using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CursoOnline.Dominio._Base;

namespace EscapeMines.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    
    }
}
