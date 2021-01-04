using System;
using System.Collections.Generic;
using System.Text;
using TodoAppMVVM.Models;
using TodoAppMVVM.Repository;

namespace TodoAppMVVM.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
       
        private readonly List<Item> newItem = new List<Item>(),
                                 updateItem = new List<Item>(),
                                 removeItem = new List<Item>(),
                              ItemContainer = new List<Item>();
        private List<string> result = new List<string>();
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            
        }
        struct Message
        {
            public string msgs;
            public string validate;

        }
        #region Service Create/Add Item
        public List<string> Add(Item data)
        {
            Message Msg;
            //LoadItem(data.TodoId);
            ItemContainer.AddRange(_itemRepository.GetItemById(data.TodoId));
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
        #endregion
        
        #region Service Update/Edit
        public List<string> Update(Item data) //--------------------------> Update new Item
        {
            Message Msg;
            ItemContainer.AddRange(_itemRepository.GetItemById(data.TodoId));
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
        #endregion

        #region Service Remove/Delete
        public List<string> RemoveItem(Item data) 
        {
            Message Msg;
            ItemContainer.AddRange(_itemRepository.GetItemById(data.TodoId));
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
        #endregion

        #region Save
        public void Save()
        {
            
            //--- Save Item
            if (newItem != null)
            {
                foreach (Item item in newItem)
                {
                    _itemRepository.Add(item);
                }
            }
            if (updateItem != null)
            {
                foreach (Item update in updateItem)
                {
                    _itemRepository.Update(update);
                }
            }
            if (removeItem != null)
            {
                foreach (Item remove in removeItem)
                {
                    _itemRepository.RemoveItem(remove.Id);
                }
            }

            Dispose();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
           
            newItem.Clear();
            updateItem.Clear();
            removeItem.Clear();
            ItemContainer.Clear();
        }
        #endregion
    }
}
