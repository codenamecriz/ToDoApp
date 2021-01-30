using Moq;
using Services.IRepository;
using Services.Queries.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TodoAppServices.UnitTest
{
    public class ItemQueryServiceTests
    {
        private readonly ItemQueryService _sut;
        private readonly Mock<IItemRepository> _itemRepositoryMock = new Mock<IItemRepository>();

        public ItemQueryServiceTests()
        {
            _sut = new ItemQueryService(_itemRepositoryMock.Object);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetTodoItemsByIdAsync_ShouldReturnAllItem_UnderTodo(int id)
        {
            //Range - Expected
            var itemId = new GetItemQuery(id);

            //_itemRepositoryMock.Setup(x => x.GetTodoItemsById(itemId)).ReturnsAsync();

            //Act
            
            var result = await _sut.GetTodoItemsByIdAsync(itemId);
            //Assert
 
            Assert.True(result != null);

        }
    }
}
