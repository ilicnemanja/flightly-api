using Flightly.Models;
using Microsoft.EntityFrameworkCore;

namespace Flightly.Data
{
    public class FlightDbContext(DbContextOptions<FlightDbContext> options) : DbContext(options)
    {
        public required DbSet<Flights> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
