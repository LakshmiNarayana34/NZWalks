using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{

    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions) 
        {
          
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seeding the difficulty data

            var difficulties = new List<Difficulty>
            {
                new Difficulty()
                {
                    Id = Guid.Parse("D5D0F328-88F6-48F9-77EA-08DD1F4ABB45"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("D5D0F328-88F6-48F9-77EA-08DD1F4ABB47"),
                    Name = "Medium"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("D5D0F328-88F6-48F9-77EA-08DD1F4ABB48"),
                    Name = "Hard"
                }
                


            };

          var region =  new List<Region>()
                        {
                            new Region()
                            {
                            Id = Guid.Parse("D5D0F328-88F6-48F9-77EA-08DD1F4ABB51"),
                            Name = "Nilotpal",
                            Code = "Dnk",
                            RegionImgUrl =null
                            },
                            new Region()
                            {
                            Id = Guid.Parse("D5D0F328-88F6-48F9-77EA-08DD1F4ABB54"),
                            Name = "prasant",
                            Code = "Ilr",
                            RegionImgUrl =null
                            }



          };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            modelBuilder.Entity<Region>().HasData(region);


        }
    }
}
