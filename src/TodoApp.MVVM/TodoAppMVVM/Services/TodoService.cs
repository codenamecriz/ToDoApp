﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoApp.MVVM.Models;
using TodoAppMVVM.Models;
using TodoAppMVVM.Repository;

namespace TodoAppMVVM.Services  // ListServices
{
    public class TodoService : ITodoService
    {
        //private readonly ITodoRepository todoRepository;
        //private readonly IGetDataQueryRepository todoQueryRepository;
        private readonly ITodoRepository todoRepository;
        //private readonly IGetDataQueryRepository todoQueryRepository;
        private readonly List<Todo> newList = new List<Todo>();
        private readonly List<Todo> updateList = new List<Todo>();
        private readonly List<Todo> removeList = new List<Todo>();
        private readonly List<Todo> ListContainer = new List<Todo>();
        private List<string> result = new List<string>();
        public TodoService(ITodoRepository _todoRepository)//, IGetDataQueryRepository _todoQueryRepository)//ITodoRepository _listRepository, IGetDataQueryRepository _todoQueryRepository)
        {
            todoRepository = _todoRepository;
            //todoQueryRepository = _todoQueryRepository;
            //todoRepository = _listRepository;
            //todoQueryRepository = _todoQueryRepository;
        }
        struct Message
        {
            public string msgs;
            public string validate;
        }
        //public List<string> catchResult(List<string> actionResult) // ----> CatchResult Message
        //{
        //    //var actionResult = msg.Split("&");
        //    var result = new List<string> { actionResult[0], actionResult[1] };
        //    return result;
        //}
        //public IEnumerable<Todo> LoadList() // ------> Load all List to Container
        //{

        //    //listRepository = new TodoModelRepository();
        //    ListContainer.AddRange(todoRepository.GetAllDatalist());
           
        //    return ListContainer;
        //}


        public List<string> Add(Todo data) //------------ Register New List
        {
            ListContainer.AddRange(todoRepository.GetAllDatalist());//LoadList();
            Message Msg;
            Msg.validate = "true";
            var checkName = 0;
            foreach (Todo checkNameRegistered in ListContainer)
            {
                if (checkNameRegistered.Name == data.Name)
                {
                    checkName = 1;
                }
            }
            if (data.Id == 0 && checkName == 0)
            {
                newList.Add(data);
                Msg.msgs = "New List Ssuccessfully Added!!!";
               
            }
            else
            {
                Msg.msgs = "Data Already Registered.!!!";
                Msg.validate = "false";
            }

            result = new List<string> { Msg.msgs, Msg.validate };

            //var result = msg + "&" + validate;
            
            return result;
        }
        public List<string> Update(Todo data) //---------------------->> Update
        {
            Message Msg;
            Msg.validate = "true";
            if (data.Id != 0 && !ListContainer.Contains(data))
            {
                updateList.Add(data);
                Msg.msgs = "List Ssuccessfully Updated!!!";
            }
            else
            {
                Msg.msgs = "Data Cant Update Please Try Again!!! ";
                Msg.validate = "false";
            }
            result = new List<string> { Msg.msgs, Msg.validate };
            //var result = msg + "&" + validate;
            return result;
        }
        public List<string> RemoveList(Todo data) // -------->> Remove
        {
            Message Msg;
            Msg.validate = "true";
            if (data.Id != 0 )
            {
                removeList.Add(data);
                Msg.msgs = "List has been Successfully Remove!";
                Msg.validate = "true";

            }
            else
            {
                Msg.msgs = "Sorry Your Request is Failed to Remove!";
                Msg.validate = "false";
            }
            result = new List<string> { Msg.msgs, Msg.validate };
            //var result = msg + "&" + validate;
            return result;
        }
        public void  Save()
        {
            //---Save List
            if (newList != null)
            {

                foreach (Todo newlist in newList)
                {
                    todoRepository.Add(newlist);
                }
            }
            if (updateList != null)
            {
                foreach (Todo update in updateList)
                {
                    todoRepository.Update(update);
                }
            }
            if (removeList != null)
            {
                foreach (Todo remove in removeList)
                {
                    todoRepository.RemoveList(remove.Id);
                }
            }
            //return newList;


            Dispose();
            //context.SaveChanges();
        }
        public void Dispose()
        {
            newList.Clear();
            updateList.Clear();
            removeList.Clear();
           
            ListContainer.Clear();
            
        }
    }
}
