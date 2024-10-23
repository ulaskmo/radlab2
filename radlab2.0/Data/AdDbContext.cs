using Microsoft.EntityFrameworkCore;
using radlab2_0.Models;

namespace radlab2_0.Data
{
    public class AdDbContext : DbContext
    {
        public AdDbContext(DbContextOptions<AdDbContext> options) : base(options) {}

        public DbSet<Ad> Ads { get; set; }
    }
}