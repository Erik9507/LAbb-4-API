using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAbb_4_API.Models
{
    public class ProgramDbContext : DbContext
    {
        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) : base(options)
        {

        }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<WebbAdress> WebbAdresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Interests>().HasData(new Interests
            { Id = 1, InterestName = "Padel", InterestDescription = "Padel is a racquet sport that combines the elements of tennis, squash and badminton.", FPersonId = 1 });
            modelBuilder.Entity<Interests>().HasData(new Interests
            { Id = 2, InterestName = "Rock climbing", InterestDescription = "A sport in which participants climb up, down or across natural rock formations or artificial rock walls.", FPersonId = 2 });
            modelBuilder.Entity<Interests>().HasData(new Interests
            { Id = 3, InterestName = "Coding", InterestDescription = "Coding makes it possible for us to create computer software, games, apps and websites.", FPersonId = 3 });
            modelBuilder.Entity<Interests>().HasData(new Interests
            { Id = 4, InterestName = "Surfing", InterestDescription = "Surfing is the sport of riding waves in an upright or prone position. Surfers catch the ocean, river, or man-made waves and glide across the surface", FPersonId = 4 });


            modelBuilder.Entity<Person>().HasData(new Person { Id = 1, Name = "Viktor", PhoneNumber = "0701234599" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 2, Name = "Lukas", PhoneNumber = "0704593288" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 3, Name = "Erik", PhoneNumber = "0707842511" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 4, Name = "Simon", PhoneNumber = "0738432077" });

            modelBuilder.Entity<WebbAdress>().HasData(new WebbAdress { Id = 1, WebbSiteName = "World Padel Tour", Webbadress = "https://www.worldpadeltour.com/en", FInterestId = 1 });
            modelBuilder.Entity<WebbAdress>().HasData(new WebbAdress { Id = 2, WebbSiteName = "Climb Europe", Webbadress = "https://climb-europe.com/", FInterestId = 2 });
            modelBuilder.Entity<WebbAdress>().HasData(new WebbAdress { Id = 3, WebbSiteName = "Code Cademy", Webbadress = "https://www.codecademy.com/", FInterestId = 3 });
            modelBuilder.Entity<WebbAdress>().HasData(new WebbAdress { Id = 4, WebbSiteName = "Surfer Today", Webbadress = "https://www.surfertoday.com/", FInterestId = 4 });

          
        }
    }
    


}
