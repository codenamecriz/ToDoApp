﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.SQLite
{
    public class DBContext : IDBContext
    {
        //public DbSet<ItemModel> Itemlists { get; set; }
        //public DbSet<TodoModel> Datalists { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(
        //        "Data Source=TodoDatabase.db");
        //    optionsBuilder.UseLazyLoadingProxies();
        //    base.OnConfiguring(optionsBuilder);
        //}
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();

        //    services.AddDbContext<ApplicationDbContext>(
        //        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
        //}

        public void CreateDb()
        {
            try
            {
                SQLiteConnection.CreateFile("TodoDatabase.db");

                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=TodoDatabase.db;Version=3;");
                m_dbConnection.Open();

                string TodoTable = "CREATE TABLE `Todo` (`TodoModelId`   INTEGER NOT NULL UNIQUE,`Name`  varchar(40),`Description`   TEXT,"
                        + "PRIMARY KEY(`TodoModelId` AUTOINCREMENT))";
                SQLiteCommand command = new SQLiteCommand(TodoTable, m_dbConnection);
                command.ExecuteNonQuery();

                string ItemTable = "CREATE TABLE `Item` ( `ItemModelId`   INTEGER NOT NULL UNIQUE,`Name`  TEXT,`Detailed`  TEXT,`Status`    TEXT,"
                           + "`TodoModelId`   INTEGER, PRIMARY KEY(`ItemModelId` AUTOINCREMENT)) ";
                command = new SQLiteCommand(ItemTable, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch { }
        }
    }
}
