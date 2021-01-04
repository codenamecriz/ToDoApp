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
   
        private SQLiteConnection connect;
        private readonly IBuildConnection _buildConnection;
        public ItemRepository(IBuildConnection buildConnection)
        {
            connect = new SQLiteConnection();
            _buildConnection = buildConnection;
        }
        #region Create/Add in Database
        public string Add(Item data) 
        {
            connect = _buildConnection.DbConnection();
    
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "INSERT INTO Item(Name, Detailed,Status,TodoModelId) VALUES(@name,@detailed,@status,@datalistId)";
            cmd.Parameters.AddWithValue("@name", data.Name);
            cmd.Parameters.AddWithValue("@detailed", data.Detailed);
            cmd.Parameters.AddWithValue("@status", data.Status);
            cmd.Parameters.AddWithValue("@datalistId", data.TodoId);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Done Save From DB SQLITE Query";

        }
        #endregion

        #region Remove/Delete in Database

        public void RemoveItem(int id)
        {
            connect = _buildConnection.DbConnection();
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "DELETE FROM Item Where ItemModelId = @id ";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
        }
        #endregion

        #region Get All Item By Id in Database
        public IEnumerable<Item> GetItemById(int id) 
        {
            var listFile = new List<Item>();
            connect = _buildConnection.DbConnection();
            connect.Open();
            string Query = "SELECT * From Item Where TodoModelId = " + id;

            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            SQLiteDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                listFile.Add(new Item()
                {
                    Id = rd.GetInt32(0),
                    Name = rd.GetString(1),
                    Detailed = rd.GetString(2),
                    Status = rd.GetString(3)
             
                });
            }
            connect.Close();
            return listFile;
        }
        #endregion

        #region Update/Edit in Database
        public string Update(Item data) 
        {
            int id = data.Id;
            string name = data.Name;
            string des = data.Detailed;
            string status = data.Status;
            connect = _buildConnection.DbConnection();

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
        #endregion
    }
}
