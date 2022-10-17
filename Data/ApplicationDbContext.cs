using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CrickAuctioner.Models;

namespace CrickAuctioner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CrickAuctioner.Models.Trophy> Trophy { get; set; }
        public DbSet<CrickAuctioner.Models.Team> Team { get; set; }
        public DbSet<CrickAuctioner.Models.PlayerAccount> PlayerAccount { get; set; }

     

       
    }
}