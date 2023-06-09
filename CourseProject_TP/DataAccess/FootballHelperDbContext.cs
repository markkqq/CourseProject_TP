using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccess.Entities;
using System.Threading.Tasks;

#nullable disable

namespace DataAccess
{
    public partial class FootballHelperDbContext : DbContext
    {
        public FootballHelperDbContext()
        {
            //Database.EnsureCreated();
        }

        public FootballHelperDbContext(DbContextOptions<FootballHelperDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<ClubEntity> Clubs { get; set; }
        public DbSet<TournamentEntity> Tournaments { get; set; }
        public DbSet<GameSessionEntity> GameSessions { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=BBI6JI9G0K\SQLEXPRESS;Database=FootballHelperFinal;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
