﻿//using System;
//using System.Collections.Generic;
//using System.Data.SQLite;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TodoAppMVVM.Models;
//using TodoAppMVVM.SQLite;

//namespace TodoApp.MVVM.Repository
//{
//    public class GetDataQueryRepository : IGetDataQueryRepository
//    {
//        //private readonly IBuildConnection context;
//        private readonly IBuildConnection context;
//        private SQLiteConnection connect;
//        public GetDataQueryRepository(IBuildConnection _context)//IBuildConnection _context)
//        {
//            //context = _context;
//            connect = new SQLiteConnection();
//            context = _context;
//        }
//        public IEnumerable<Todo> GetAllDatalist() // Get all Data
//        {
//            connect = context.DbConnection();
//            connect.Open();
//            //List<string> listFile = new List<string>();
//            var listFile = new List<Todo>();


//            string query = "Select * from Todo";
//            SQLiteCommand cmd = new SQLiteCommand(query, connect);
//            SQLiteDataReader rd = cmd.ExecuteReader();

//            while (rd.Read())
//            {
//                listFile.Add(new Todo()
//                {
//                    Id = rd.GetInt32(0),
//                    Name = rd.GetString(1),
//                    Description = rd.GetString(2)
//                });

//            }
//            connect.Close();
//            return listFile;
//            //throw new NotImplementedException();
//        }
//        public IEnumerable<Item> GetAllItem(int id) //--------------------------------> Get All Itemm By Id
//        {
//            var listFile = new List<Item>();
//            connect = context.DbConnection();
//            connect.Open();
//            string Query = "SELECT * From Item Where TodoModelId = " + id;

//            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
//            SQLiteDataReader rd = cmd.ExecuteReader();

//            while (rd.Read())
//            {

//                listFile.Add(new Item()
//                {
//                    Id = rd.GetInt32(0),
//                    Name = rd.GetString(1),
//                    Detailed = rd.GetString(2),
//                    Status = rd.GetString(3)
//                    // etc... (0, 1 refer to the column index)
//                });
//            }
//            connect.Close();
//            return listFile;
//            //throw new NotImplementedException();
//        }
//    }
//}
