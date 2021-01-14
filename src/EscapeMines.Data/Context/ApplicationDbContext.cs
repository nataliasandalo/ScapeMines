using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EscapeMines.Domain.Board;
using Microsoft.EntityFrameworkCore;

namespace EscapeMines.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Board> Board { get; set; }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
