using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using TodoAppMVVM.Models;
using TodoAppMVVM.SQLite;

namespace TodoAppMVVM.Repository
{
    public class ItemRepository : IItemRepository
    {
        //private readonly IBuildConnection context;
        private SQLiteConnection connect;
        private readonly BuildConnection context;
        public ItemRepository()//IBuildConnection _context)
        {
            //context = _context;
            connect = new SQLiteConnection();
            context = new BuildConnection();
        }
        public string Add(ItemModel data) //-------------------------> Insert Item
        {
            connect = context.DbConnection();
            //string Query = "INSERT INTO Itemlists(Name, Detailed,Status,DatalistId) VALUES('" + datas[0] + "', '" + datas[1] + "',)";
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "INSERT INTO Itemlists(Name, Detailed,Status,DatalistId) VALUES(@name,@detailed,@status,@datalistId)";
            cmd.Parameters.AddWithValue("@name", data.Name);
            cmd.Parameters.AddWithValue("@detailed", data.Detailed);
            cmd.Parameters.AddWithValue("@status", data.Status);
            cmd.Parameters.AddWithValue("@datalistId", data.TodoModelId);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Done Save From DB SQLITE Query";

        }

        public void Delete(int id)
        {
            connect = context.DbConnection();
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "DELETE FROM Item Where ItemModelId = @id ";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public IEnumerable<ItemModel> GetAll(int id) //--------------------------------> Get All Itemm By Id
        {
            var listFile = new List<ItemModel>();
            connect = context.DbConnection();
            connect.Open();
            string Query = "SELECT * From Item Where TodoModelId = " + id;

            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            SQLiteDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                listFile.Add(new ItemModel()
                {
                    ItemModelId = rd.GetInt32(0),
                    Name = rd.GetString(1),
                    Detailed = rd.GetString(2),
                    Status = rd.GetString(3)
                    // etc... (0, 1 refer to the column index)
                });
            }
            connect.Close();
            return listFile;
            //throw new NotImplementedException();
        }
        public string Update(ItemModel data) //------------------------------>> Update
        {
            int id = data.ItemModelId;
            string name = data.Name;
            string des = data.Detailed;
            string status = data.Status;
            connect = context.DbConnection();

            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "UPDATE Item SET Name = @name , Detailed = @des, Status = @status WHERE ItemModelId = " + id;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@des", des);
            cmd.Parameters.AddWithValue("@status", status);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Done Update From DB SQLITE Query";
        }
    }
}
