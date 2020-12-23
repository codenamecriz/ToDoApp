using System;
using System.Collections.Generic;
using System.Text;
using TodoAppMVVM.Models;
using TodoAppMVVM.Repository;

namespace TodoAppMVVM.Services
{
    public class ItemService : IItemService
    {
        //private IItemRepository itemRepository;
        private readonly IItemRepository itemRepository ;
        //private readonly IGetDataQueryRepository todoQueryRepository ;
        private readonly List<Item> newItem = new List<Item>();
        private readonly List<Item> updateItem = new List<Item>();
        private readonly List<Item> removeItem = new List<Item>();
        private readonly List<Item> ItemContainer = new List<Item>();
        private List<string> result = new List<string>();
        public ItemService(IItemRepository _itemRepository)//, IGetDataQueryRepository _todoQueryRepository)
        {
            //todoQueryRepository = _todoQueryRepository;
            itemRepository = _itemRepository;
            //itemRepository = _itemRepository;
        }
        struct Message
        {
            public string msgs;
            public string validate;

        }
        //public IEnumerable<Item> LoadItem(int Id) // ------> Load all Item to Container
        //{

        //    //itemRepository = new ItemRepository();
            

        //    return ItemContainer;
        //}
        public List<string> Add(Item data) // -----------------> Insert new item
        {
            Message Msg;
            //LoadItem(data.TodoId);
            ItemContainer.AddRange(itemRepository.GetItemById(data.TodoId));
            Console.WriteLine("------>"+data.Id);
            if (data.Id == 0 && !ItemContainer.Contains(data))
            {
                newItem.Add(data);

                Msg.msgs = "New Item Successfully Added!!";
                Msg.validate = "true";
            }
            else
            {
                Msg.msgs = "Data Already Registered.!!!";
                Msg.validate = "false";
            }

            result = new List<string> { Msg.msgs, Msg.validate };
            return result;

        }
        public List<string> Update(Item data) //--------------------------> Update new Item
        {
            Message Msg;
            ItemContainer.AddRange(itemRepository.GetItemById(data.TodoId));
            //Console.WriteLine(!ItemContainer.Contains(data));
            //Console.WriteLine((data.ItemModelId));
            if (data.Id != 0 && !ItemContainer.Contains(data))
            {
                updateItem.Add(data);
                Msg.msgs = "Item Successfully Updated!!";
                Msg.validate = "true";
            }
            else
            {
                Msg.msgs = "Request an Update Failed. Please try Again.!! ";
                Msg.validate = "false";
            }

            result = new List<string> { Msg.msgs, Msg.validate };
            return result;

        }
        public List<string> RemoveItem(Item data) //------------------------------------- >> Remove Item
        {
            Message Msg;
            ItemContainer.AddRange(itemRepository.GetItemById(data.TodoId));
            if (data.Id != 0 )
            {
                removeItem.Add(data);
                Msg.msgs = "Your Request Has Been Successfull. Item has been Remove.!";
                Msg.validate = "true";
            }
            else
            {
                Msg.msgs = "Failed to Remove the Item";
                Msg.validate = "false";
            }

            result = new List<string> { Msg.msgs, Msg.validate };
            return result;

        }
        public void Save()
        {
            
            //--- Save Item
            if (newItem != null)
            {
                foreach (Item item in newItem)
                {
                    itemRepository.Add(item);
                }
            }
            if (updateItem != null)
            {
                foreach (Item update in updateItem)
                {
                    itemRepository.Update(update);
                }
            }
            if (removeItem != null)
            {
                foreach (Item remove in removeItem)
                {
                    itemRepository.RemoveItem(remove.Id);
                }
            }

            Dispose();
        }
        public void Dispose()
        {
           
            newItem.Clear();
            updateItem.Clear();
            removeItem.Clear();
            ItemContainer.Clear();
        }
    }
}
