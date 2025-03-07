using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        { }
                protected override void OnModelCreating(ModelBuilder builder)
                {
                    base.OnModelCreating(builder);
                    var readerRoleId = "cd782fde-0830-4bc5-bce6-5a8c66a9b869";
                    var writerRoleId = "aa1d526c-8f2b-469d-a864-d0d88192113c";

                    var roles = new List<IdentityRole>()
                    {
                        new IdentityRole
                        {
                            Id = readerRoleId,
                            Name ="Reader",
                            ConcurrencyStamp = readerRoleId,
                            NormalizedName = "Reader".ToUpper()
                        },
                        new IdentityRole
                        {
                            Id = writerRoleId,
                            Name ="Writer",
                            ConcurrencyStamp = writerRoleId,
                            NormalizedName = "Writer".ToUpper()
                        }

                    };

            builder.Entity<IdentityRole>().HasData(roles);


                }

    }

   
        
    
}
