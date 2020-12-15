using System;
using System.Collections.Generic;
using System.Text;
using TodoAppMVVM.Models;
using TodoAppMVVM.Repository;

namespace TodoAppMVVM.Services
{
    public class TodoService : ITodoService
    {
        private ITodoRepository todoRepository;
        private readonly List<TodoModel> newList = new List<TodoModel>();
        private readonly List<TodoModel> updateList = new List<TodoModel>();
        private readonly List<TodoModel> removeList = new List<TodoModel>();
        private readonly List<TodoModel> ListContainer = new List<TodoModel>();
        private List<string> result = new List<string>();
        public TodoService(ITodoRepository _listRepository)
        {
            todoRepository = _listRepository;
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
        public IEnumerable<TodoModel> LoadList() // ------> Load all List to Container
        {

            //listRepository = new TodoModelRepository();
            ListContainer.AddRange(todoRepository.GetAllDatalist());

            return ListContainer;
        }


        public List<string> RegisterNewList(TodoModel data) //------------ Register New List
        {
            LoadList();
            Message Msg;
            Msg.validate = "true";
            var checkName = 0;
            foreach (TodoModel checkNameRegistered in ListContainer)
            {
                if (checkNameRegistered.Name == data.Name)
                {
                    checkName = 1;
                }
            }
            if (data.TodoModelId == 0 && checkName == 0)
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
        public List<string> UpdateList(TodoModel data) //---------------------->> Update
        {
            Message Msg;
            Msg.validate = "true";
            if (data.TodoModelId != 0 && !ListContainer.Contains(data))
            {
                updateList.Add(data);
                Msg.msgs = "List Ssuccessfully Updatedss!!!";
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
        public List<string> RemoveList(TodoModel data) // -------->> Remove
        {
            Message Msg;
            Msg.validate = "true";
            if (data.TodoModelId != 0 )
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

                foreach (TodoModel newlist in newList)
                {
                    todoRepository.Add(newlist);
                }
            }
            if (updateList != null)
            {
                foreach (TodoModel update in updateList)
                {
                    todoRepository.Update(update);
                }
            }
            if (removeList != null)
            {
                foreach (TodoModel remove in removeList)
                {
                    todoRepository.Delete(remove.TodoModelId);
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
