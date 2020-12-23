﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using TodoAppMVVM.Models;
using TodoAppMVVM.SQLite;

namespace TodoAppMVVM.Repository
{
    public class TodoRepository : ITodoRepository
    {
        //private readonly IBuildConnection context;
        private SQLiteConnection connect;
        private readonly IBuildConnection context;
        public TodoRepository(IBuildConnection _context)//IBuildConnection _context)
        {
            //context = _context;
            connect = new SQLiteConnection();
            context = _context;
        }

        public IEnumerable<Todo> GetAllDatalist() // Get all Data
        {
            connect = context.DbConnection();
            connect.Open();
            //List<string> listFile = new List<string>();
            var listFile = new List<Todo>();


            string query = "Select * from Todo";
            SQLiteCommand cmd = new SQLiteCommand(query, connect);
            SQLiteDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                listFile.Add(new Todo()
                {
                    Id = rd.GetInt32(0),
                    Name = rd.GetString(1),
                    Description = rd.GetString(2)
                });

            }
            connect.Close();
            return listFile;
            //throw new NotImplementedException();
        }


        public string Add(Todo data) // Add to Datalist table
        {
            var name = data.Name;
            var description = data.Description;

            connect = context.DbConnection();
            connect.Open();
            string Query = "INSERT INTO Todo(Name, Description) VALUES('" + name + "', '" + description + "')";

            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Done Save From DB SQLITE Query";
            //throw new NotImplementedException();
        }

        public string Update(Todo data)  // --------------> Update
        {
            int id = data.Id;
            string name = data.Name;
            string des = data.Description;
            connect = context.DbConnection();
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "UPDATE Todo SET Name = @name , Description = @des WHERE TodoModelId = " + id;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@des", des);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Update Succcessfully";
            //throw new NotImplementedException();
        }
       

        public void RemoveList(int id) // -------------------> delete datalist
        {
            //string[] datas = data.Split('&');
            //var id = datas[0];
            //var tableName = datas[1];
            //var idName = "";
            //if (tableName == "Itemlists")
            //{
            //    idName = "ItemlistId";
            //}
            //else { idName = "DatalistId"; }
            connect = context.DbConnection();
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "DELETE FROM Todo where TodoModelId = @id ";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            //return "Successfuly Deleted! From DB SQLITE Query";
            //throw new NotImplementedException();
        }


    }
}
