using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using CourseProject_TP.DataAccess.Entities;
namespace CourseProject_TP.DataAccess.AppContext
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BBI6JI9G0K\\SQLEXPRESS;Database=marq;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<TournamentEntity> marq => Set<TournamentEntity>();
        
    }
}
