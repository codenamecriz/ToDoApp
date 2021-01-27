using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Serilog;
using Services;
using Services.Commands.Items;
using Services.Commands.Todos;
using Services.Queries.Items;
using Services.Queries.Todos;
using TodoApp.API.Data;
using Domain.IRepository;
using TodoApp.API.Helpers.Filters;

namespace TodoApp.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
       
        public Startup(IConfiguration configure)
        {
            Configuration = configure;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //Log.Information("Connecting to Database");
            
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseMySql(Configuration.GetConnectionString("TodoAppConnection"), mySqlOptionsAction: MySqlOptions =>
                    {
                        MySqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(1), errorNumbersToAdd: null);
                    });
            });

            /*var host = Configuration["DBHost"] ?? "db";
            var port = Configuration["DBPort"] ?? "3306";

            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseMySql($"server={host};port={port}; userid=root; password=testroot;database=ppg_todo", builder =>
                {
                    builder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(1), null);
                });
            }); */

            services.AddControllers(opt =>
                {
                    opt.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(mvcConfig => mvcConfig.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddNewtonsoftJson(s => { s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });
                //.ConfigureApiBehaviorOptions(options =>
                //{
                //    options.InvalidModelStateResponseFactory = context =>
                //    {
                //        // Get an instance of ILogger (see below) and log accordingly.
                    
                //        return new BadRequestObjectResult(context.ModelState);
                //    };
                //});
            

            //services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddTransient<IDbAuthentication, DbAutentication>();
           
            services.AddScoped<IItemQueryService, ItemQueryService>();
            services.AddScoped<IItemCommandService, ItemCommandService>();

            services.AddScoped<ITodoQueryService, TodoQueryService>();
            services.AddScoped<ITodoCommandService, TodoCommandService>();



            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(Startup));

            //var assembly = AppDomain.CurrentDomain.Load("Handlers");
            //services.AddMediatR(assembly);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                //options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            PrepDb.PrepPopulation(app);
            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllers();
            });
        }
    }
}
