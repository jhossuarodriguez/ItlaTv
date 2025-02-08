using Microsoft.EntityFrameworkCore;
using ItlaTv.Models;

namespace ItlaTv.Models
{
    public class StreamingContext : DbContext
    {
        public StreamingContext(DbContextOptions<StreamingContext> options) : base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Productora> Productoras { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}
