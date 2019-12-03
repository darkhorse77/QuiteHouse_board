using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiteHouse_board.Model.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Boards> Boards { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<Posts> Posts { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ImageBoardDB;Trusted_Connection=True;");
        }
    }
}
