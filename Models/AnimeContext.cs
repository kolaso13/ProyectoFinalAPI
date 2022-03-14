using Microsoft.EntityFrameworkCore;

namespace WebApiAnimeProyecto.Models
{
    public class AnimeContext : DbContext
    {
        public AnimeContext(DbContextOptions<AnimeContext> options)
            : base(options)
        {
        }

        public DbSet<AnimeData> AnimeData { get; set; }
        public DbSet<User> Usuarios { get; set; }
    }
}