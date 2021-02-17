using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext //IEntityTypeConfiguration<Item>
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }
        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes();
      
            base.OnModelCreating(modelBuilder);
         

        }
    }
}
