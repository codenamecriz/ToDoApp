using Data;
using Domain.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonWithEFCore
{
    internal class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
            }
        }
        public static void SeedData(DataContext context)
        {
            
            System.Console.WriteLine("Applaying Migration.");
            context.Database.Migrate();
            if (!context.Items.Any())
            {
                //adding sample data for debuging purposes.
                context.Items.Add(new Item
                {   Id = 1,Name = "House", Addresses = new Address
                    {
                        Country = "Philippines",
                        City = "Puerto Princesa City",
                        Bgy = "San Manuel"
                        //new Address()
                        //{
                        //    Country = "Philippines",
                        //    City = "Puerto",
                        //    Bgy = ""
                        //    //LocalAddress = new List<AddressDetails>()
                        //    //{
                        //    //    new AddressDetails()
                        //    //    {
                        //    //        City = "Palawan",
                        //    //        Bgy = "San Manuel"
                        //    //    }
                        //    //}
                        //}


                     }
                });
                context.SaveChanges();
                
            }
        }
    }
}