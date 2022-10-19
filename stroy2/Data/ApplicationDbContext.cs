using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using stroy2.Models;

namespace stroy2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Consult> Consult { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
   
    }
}