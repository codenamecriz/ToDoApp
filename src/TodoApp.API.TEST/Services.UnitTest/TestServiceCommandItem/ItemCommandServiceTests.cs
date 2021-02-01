using FluentAssertions;
using Moq;
using NSubstitute;
using Services;
using Services.Commands.Items;
using Services.Commands.Items.Request;
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
        public async Task CreateItemAsync_ShouldBeSuccess_WhenCreated()
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
            //Mock<AppDbContext> dbContext = new Mock<AppDbContext>();
          
            _itemRepositoryMock.Setup(x => x.CreateItem(item));
            //_itemRepositoryMock.Setup(x => x.SaveChanges());
            var result = await _sut.CreateItemAsync(itemData);
            _itemRepositoryMock.Verify(x => x.SaveChanges(), Times.Exactly(1));

            //Assert
            //int val = result.Id;
            ////result.Should().Be()
            //Assert.True(result.Id > 0);

        }
        [Theory]
        [InlineData(4, "House", "Detalye", EnumItemStatus.Done, 1)]
        //[InlineData(4, "", "Ditalye", EnumItemStatus.Done, 1)]
        public async Task CreateItemAsync_ShouldFaild_If_The_EntryName_Is_ExistInDatabase(
            int id,
            string name,
            string details,
            EnumItemStatus status,
            int todoId)
        {
            var expected = new ResponseItemDto(0);
            var itemData = new CreateItemCommand
            {
                Name = name,
                Details = details,
                Status = status,
                TodoId = todoId
            };
            var baseCommand = new BaseCommand { Id = id, Name = name};
            //Actual
        
            _dbAuthenticationMock.Setup(x => x.CheckingIfExist(It.IsAny<BaseCommand>())).ReturnsAsync(() => 1);
            var result = await _sut.CreateItemAsync(itemData);
            
            //var finalResult = result.Returns();
            //int res = result.Id;
            result.Should().Be(expected);
            //Assert

        }

        //[Theory]
        //[InlineData(4, "House", "", EnumItemStatus.Done, 1)]
        ////[InlineData(4, "", "Ditalye", EnumItemStatus.Done, 1)]
        //public async Task CreateItemAsync_ShouldFaild_IfOneOfTheFieldIsEmptyAsync(
        //    int id,
        //    string name,
        //    string details,
        //    EnumItemStatus status,
        //    int todoId)
        //{
        //    var itemData = new CreateItemCommand
        //    {
        //        Name = name,
        //        Details = details,
        //        Status = status,
        //        TodoId = todoId
        //    };
        //    var baseCommand = new BaseCommand { Id = id, Name = name };
        //    //Actual
        //    var item = GetItemByIdSampleData()[0];
        //    _dbAuthenticationMock.Setup(x => x.CheckingIfExist(baseCommand)).ReturnsAsync(1);


        //}

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
