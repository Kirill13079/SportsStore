using SportsStore.Model.Entities;
using System.Data.Entity;

namespace SportsStore.Model.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
