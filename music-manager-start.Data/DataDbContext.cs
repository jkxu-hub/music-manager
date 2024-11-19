using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song { Id = Guid.Parse("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3"), Title = "Circle With Me", Artist = "Spiritbox", Album = "Spiritbox", Genre = "Metal", Rating = 10, FilePath = "/images/pb.png"},
                new Song { Id = Guid.Parse("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45"), Title = "Notes on a River Town", Artist = "Pony Bradshaw", Album = "Canyon", Genre = "Folk", Rating = 10, FilePath = "/images/pb.png" }

            );
        }

    }
}
