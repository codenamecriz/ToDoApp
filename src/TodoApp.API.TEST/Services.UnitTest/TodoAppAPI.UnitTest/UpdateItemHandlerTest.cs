using Moq;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.API.Models;
using Xunit;
using TodoApp.API.Enum;

namespace TodoAppServices.UnitTest.TodoAppAPI.UnitTest
{
    public class UpdateItemHandlerTest
    {
        [Theory]
        [InlineData(4,1,"Updatename","UpdateDetails",EnumItemStatus.Done,1)]
        public async Task Handle_UpdateItemRequest_ShouldReturnId_WhenSuccessfulyUpdated(int expected, int id, string name, string details, EnumItemStatus status, int todoId)
        {
            

            var itemUpdate = new Item()
            {
                Id = id,
                Name = name,
                Details = details,
                Status = status,
                TodoId = todoId
            };

            var itemRepo = new Mock<IItemRepository>();
            itemRepo.Setup(x => x.GetItemById(1)).ReturnsAsync(itemUpdate);

        }
    }
}
