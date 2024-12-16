using Microsoft.EntityFrameworkCore;
using jit_access_manager.Models;

namespace jit_access_manager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AccessRequest> AccessRequests { get; set; }
    }
}
