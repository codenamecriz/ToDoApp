﻿using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Repository
{
    public interface IDatalistRepository
    {
        
        IEnumerable<Datalist> GetAllDatalist();
        string Add(Datalist datalist);
        string Update(Datalist data);
        string Find(Datalist data);
        string Find(Itemlist data);
        void Delete(int id);
    }
}
