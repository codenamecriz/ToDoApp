using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Diagnostics;
using System.Linq;

namespace JsonObjectSample
{
    public class IceCream
    {
        public int IceCreamId { get; set; }
        public string Name { get; set; }
        public JsonObject<Energy> Energy { get; set; }
        public JsonObject<string[]> Comments { get; set; }
    }

    public class Energy
    {
        public double Kilojoules { get; set; }
        public double Kilocalories { get; set; }
    }

    public class Context : DbContext
    {
        public virtual DbSet<IceCream> IceCreams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=127.0.0.1;port=3306;user=testroot;password=testroot;database=jsonobjectsample",
                    b => b.ServerVersion(new ServerVersion("8.0.18-mysql")));
        }
    }

    internal class Program
    {
        private static void Main()
        {
            using (var context = new Context())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.IceCreams.AddRange(
                    new IceCream
                    {
                        Name = "Vanilla",
                        Energy = new Energy
                        {
                            Kilojoules = 866.0,
                            Kilocalories = 207.0
                        },
                        Comments = new[]
                        {
                            "First!",
                            "Delicios!"
                        }
                    },
                    new IceCream
                    {
                        Name = "Chocolate",
                        Energy = new Energy
                        {
                            Kilojoules = 904.0,
                            Kilocalories = 216.0
                        },
                        Comments = new[]
                        {
                            "My husband linkes this one a lot."
                        }
                    });

                context.SaveChanges();
            }

            using (var context = new Context())
            {
                var result = context.IceCreams
                    .OrderBy(e => e.IceCreamId)
                    .ToList();

                Debug.Assert(result.Count == 2);

                Debug.Assert(result[0].Name == "Vanilla");
                Debug.Assert(result[0].Energy.Object.Kilojoules == 866.0);
                Debug.Assert(result[0].Comments.Object.Length == 2);
                Debug.Assert(result[0].Comments.Object[0] == "First!");
            }
        }
    }
}
