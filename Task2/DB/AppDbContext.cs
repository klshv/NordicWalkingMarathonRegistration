using Microsoft.EntityFrameworkCore;

using Task2.Models;

namespace Task2.DB {

    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Participant> Participants { get; set; }

    }

}