/*
  In-memory Database context to store/manage banners
 */
using Microsoft.EntityFrameworkCore;

namespace BannerflowApi.Models
{
    public class BannerContext : DbContext
    {
        public BannerContext(DbContextOptions<BannerContext> options)
            : base(options)
        {
        }

        public DbSet<Banner> Banners { get; set; }

    }
}