
using FluentAssertions;
using Moq;
using Services;
using Services.Commands.Items.Request;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.API.Enum;
using TodoApp.API.Models;
using Xunit;


namespace TodoAppServices.UnitTest
{
    //[Collection("Live tests")]
    //[CollectionDefinition("Live tests")]
    public class DbAuthenticationTests //: IClassFixture<IDbAuthentication>
    {
        private readonly DbAutentication _sut;
        private readonly Mock<IItemRepository> _itemRepositoryMock = new Mock<IItemRepository>();
        private readonly Mock<ITodoRepository> _todoRepositoruMock = new Mock<ITodoRepository>();

        public DbAuthenticationTests()
        {
            _sut = new DbAutentication(_itemRepositoryMock.Object, _todoRepositoruMock.Object);
        }


        [Theory]
        [InlineData(1 , 1, "House")]
        //[InlineData(0, 1, "Window")]
        public async void CheckingIfExist_FindingNameInDataInDatabase(int expected,int id, string name)
        {
            //var expected = 1;
              _itemRepositoryMock.Setup(x => x.GetAllItem())
                .Returns( GetItemByIdSampleData());
            //_itemRepositoryMock.Setup(x => x.GetAllItem()).ReturnsAsync(() => null);

            //Actual
            BaseCommand item = new BaseCommand { Id = id, Name = name };
            var result = await _sut.CheckingIfExist(item);

            //Assert
            result.Should().Be(expected);
            //Assert.Equal(expected, result);
         

        }
        private async Task<IEnumerable<Item>> GetItemByIdSampleData()
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
