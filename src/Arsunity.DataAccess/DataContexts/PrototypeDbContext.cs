using Arsunity.Interfaces.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Arsunity.DataAccess.DataContexts
{
    internal class PrototypeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public PrototypeDbContext(DbContextOptions<PrototypeDbContext> options)
            : base(options)
        {
        }
    }
}
