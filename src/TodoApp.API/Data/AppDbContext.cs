using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            /*                                                 For Example Purposes
             * builder.Property(b => b.Party).HasConversion(c => c.ToString(), c => Enum.Parse<Party>(c));

            modelBuilder.Entity<Item>()
                .Property(s => s.Status)
                .HasConversion(c => c.ToString(), c => Enum.Parse<Item.ItemStatus>(c));

            modelBuilder.Entity<Item>()
               .Property(s => s.Status)
               .HasConversion<string>();
           


            var converter = new ValueConverter<EquineBeast, string>(
                                v => v.ToString(),
                                v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));

            modelBuilder
                .Entity<Item>()
                .Property(e => e.Status)
                .HasConversion(converter);*/

            base.OnModelCreating(modelBuilder); 
        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=127.0.0.1;port=3306;user=testroot;password=testroot;database=ppg_todo")
                .UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole()
                                .AddFilter(level => level > LogLevel.Information)))
                          .EnableSensitiveDataLogging()
                          .EnableDetailedErrors();
        }*/

    }
}
