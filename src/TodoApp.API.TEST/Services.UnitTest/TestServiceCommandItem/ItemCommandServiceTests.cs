using FluentAssertions;
using Moq;
using NSubstitute;
using Services;
using Services.Commands.Items;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.Enum;
using TodoApp.API.Models;
using Xunit;

namespace TodoAppServices.UnitTest.TestServiceCommandItem
{
    public class ItemCommandServiceTests //: IDisposable
    {
        private readonly ItemCommandService _sut;
        private readonly Mock<IItemRepository> _itemRepositoryMock = new Mock<IItemRepository>();
        private readonly Mock<IDbAuthentication> _dbAuthenticationMock = new Mock<IDbAuthentication>();

        public ItemCommandServiceTests()
        {
            _sut = new ItemCommandService(_itemRepositoryMock.Object, _dbAuthenticationMock.Object);
        }

        [Fact]
        public async Task CreateItemAsync_ShouldReturnId_WhenSuccessfulyCreated()
        {
            //Range - Expected
            var itemData = new CreateItemCommand 
            {
                Name = "Bahay",
                Details = "Ditalye",
                Status = EnumItemStatus.Done,
                TodoId = 1
            };
            //Actual
            var item = GetItemByIdSampleData()[0];

            //_itemRepositoryMock.Setup(x => x.GetAllItem()).ReturnsAsync(GetItemByIdSampleData());

            //_itemRepositoryMock.Setup(x => x.SaveChanges()).Returns((Delegate)_itemRepositoryMock.Setup(x => x.CreateItem(itemToSave)).Returns(CreatedItem()));
            Mock<AppDbContext> dbContext = new Mock<AppDbContext>();

            _itemRepositoryMock.Setup(x => x.CreateItem(item));
            //_itemRepositoryMock.Setup(x => x.SaveChanges());
            var result = await _sut.CreateItemAsync(itemData);
            _itemRepositoryMock.Verify(x => x.SaveChanges(), Times.Exactly(1));

            //Assert
            //int val = result.Id;
            ////result.Should().Be()
            //Assert.True(result.Id > 0);

        }
        private List<Item> GetItemByIdSampleData()
        {
            var itemData = new List<Item>
            {
                new Item { Id = 1, Name = "House", Details = "Cleaning" , Status = EnumItemStatus.Done ,TodoId = 1},
                new Item { Id = 2, Name = "Pet", Details = "Feeding" , Status = EnumItemStatus.Pending ,TodoId = 1},
                new Item { Id = 3, Name = "Office", Details = "Submit Reposrt" , Status = EnumItemStatus.Pending ,TodoId = 1},
            };

            return itemData;
        }
    }

}
