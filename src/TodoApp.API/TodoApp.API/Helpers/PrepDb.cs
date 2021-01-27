using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TodoApp.API.Enum;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        public static void SeedData(AppDbContext context)
        {
            System.Console.WriteLine("Applaying Migration.");
            context.Database.Migrate();
            if (!context.Todos.Any())
            {
                //adding sample data for debuging purposes.
                context.Todos.Add(new Todo
                {
                    Id = 1,
                    Name = "House",
                    Description = "Cleaning"
                });
                context.SaveChanges();
                context.Items.Add(new Item
                {
                    Id = 1,
                    Name = "Windows",
                    Details = "Cleaning Dust",
                    Status = EnumItemStatus.Pending,
                    TodoId = 1

                });
                context.Items.Add(new Item
                {
                    Id = 2,
                    Name = "Flore",
                    Details = "Sweep",
                    Status = EnumItemStatus.Done,
                    TodoId = 1

                });
                context.SaveChanges();
            }
        }
    }
}
