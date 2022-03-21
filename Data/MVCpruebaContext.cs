using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiAnimeProyecto.Models;

    public class MVCpruebaContext : DbContext
    {
        public MVCpruebaContext (DbContextOptions<MVCpruebaContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiAnimeProyecto.Models.AnimeData> AnimeData { get; set; }

        public DbSet<WebApiAnimeProyecto.Models.User> User { get; set; }

        public DbSet<WebApiAnimeProyecto.Models.Anime_User> Anime_User { get; set; }
    }
