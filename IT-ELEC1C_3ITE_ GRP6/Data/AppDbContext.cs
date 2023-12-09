using InnoNet.Data.Models;
using IT_ELEC1C_3ITE__GRP6.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_ELEC1C_3ITE__GRP6.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
