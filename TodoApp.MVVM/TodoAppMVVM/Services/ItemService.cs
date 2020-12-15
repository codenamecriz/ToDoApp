using System;
using System.Collections.Generic;
using System.Text;
using TodoAppMVVM.Models;
using TodoAppMVVM.Repository;

namespace TodoAppMVVM.Services
{
    public class ItemService : IItemService
    {
        private IItemRepository itemRepository;
        private readonly List<ItemModel> newItem = new List<ItemModel>();
        private readonly List<ItemModel> updateItem = new List<ItemModel>();
        private readonly List<ItemModel> removeItem = new List<ItemModel>();
        private readonly List<ItemModel> ItemContainer = new List<ItemModel>();
        private List<string> result = new List<string>();
        public ItemService(IItemRepository _itemRepository)
        {
            itemRepository = _itemRepository;
        }
        struct Message
        {
            public string msgs;
            public string validate;
        }
        public IEnumerable<ItemModel> LoadItem(int Id) // ------> Load all Item to Container
        {

            //itemRepository = new ItemRepository();
            ItemContainer.AddRange(itemRepository.GetAll(Id));

            return ItemContainer;
        }
        public List<string> RegisterNewItem(ItemModel data) // -----------------> Insert new item
        {
            Message Msg;
            LoadItem(data.TodoModelId);
            if (data.ItemModelId == 0 && !ItemContainer.Contains(data))
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
        public List<string> UpdateItem(ItemModel data) //--------------------------> Update new Item
        {
            Message Msg;
            LoadItem(data.TodoModelId);
            if (data.ItemModelId != 0 && !ItemContainer.Contains(data))
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
        public List<string> RemoveItem(ItemModel data) //------------------------------------- >> Remove Item
        {
            Message Msg;
            LoadItem(data.TodoModelId);
            if (data.ItemModelId != 0 )
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
                foreach (ItemModel item in newItem)
                {
                    itemRepository.Add(item);
                }
            }
            if (updateItem != null)
            {
                foreach (ItemModel update in updateItem)
                {
                    itemRepository.Update(update);
                }
            }
            if (removeItem != null)
            {
                foreach (ItemModel remove in removeItem)
                {
                    itemRepository.Delete(remove.ItemModelId);
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
