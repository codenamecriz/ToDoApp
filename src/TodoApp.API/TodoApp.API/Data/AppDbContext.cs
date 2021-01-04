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
        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=127.0.0.1;port=3306;user=root;database=todoAppdb")
                .UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole()
                                .AddFilter(level => level > LogLevel.Information)))
                          .EnableSensitiveDataLogging()
                          .EnableDetailedErrors();
        }
    }
}
