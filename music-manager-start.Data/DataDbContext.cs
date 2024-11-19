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
                new Song { Id = Guid.Parse("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"), Title = "When the Party's Over", Artist = "Billie Eilish", Album = "When We All Fall Asleep, Where Do We Go?", Genre = "Pop", Rating = 10, FilePath = "/images/be1.jpg" },
                new Song { Id = Guid.Parse("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"), Title = "Utah", Artist = "French Cassettes", Album = "The Great Escape", Genre = "Indie", Rating = 10, FilePath = "/images/fc.jpg" },
                new Song { Id = Guid.Parse("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"), Title = "Something Real", Artist = "Post Malone", Album = "Twelve Carat Toothache", Genre = "Hip Hop", Rating = 10, FilePath = "/images/pm.png" },
                new Song { Id = Guid.Parse("5d7686e9-b672-43d5-aec2-4bb3ffd9b665"), Title = "Bad Guy", Artist = "Billie Eilish", Album = "When We All Fall Asleep, Where Do We Go?", Genre = "Pop", Rating = 10, FilePath = "/images/be1.jpg" },
                new Song { Id = Guid.Parse("6134ece0-f465-4102-b5e6-54afaebc1c19"), Title = "My Strange Addiction", Artist = "Billie Eilish", Album = "When We All Fall Asleep, Where Do We Go?", Genre = "Pop", Rating = 10, FilePath = "/images/be1.jpg" },
                new Song { Id = Guid.Parse("ba62c87f-5a86-4f9b-85b5-16ba4ad39e30"), Title = "Birds Of A Feather", Artist = "Billie Eilish", Album = "Hit Me Hard And Soft", Genre = "Pop", Rating = 10, FilePath = "/images/be2.png" },
                new Song { Id = Guid.Parse("dd906bcb-12b7-4cb1-9231-603d4f544390"), Title = "The Greatest", Artist = "Billie Eilish", Album = "Hit Me Hard And Soft", Genre = "Pop", Rating = 10, FilePath = "/images/be2.png" }
            );
        }

    }
}
