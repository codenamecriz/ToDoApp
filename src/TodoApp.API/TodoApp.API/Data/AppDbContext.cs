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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseMySql("server=127.0.0.1;port=3306;user=testroot;password=testroot;database=ppg_todo")
        //        .UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole()
        //                        .AddFilter(level => level > LogLevel.Information)))
        //                  .EnableSensitiveDataLogging()
        //                  .EnableDetailedErrors();
        //}
       
    }
}
