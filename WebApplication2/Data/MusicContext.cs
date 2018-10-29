using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoodTubeOriginal.Models;



namespace MoodTubeOriginal.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {
        }

        public DbSet<Mood> Moods { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Singer> Singers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mood>().ToTable("Mood");
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<Singer>().ToTable("Singer");
        }
    }
}
