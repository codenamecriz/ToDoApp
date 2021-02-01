using FluentAssertions;
using Moq;
using Services.IRepository;
using Services.Queries.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

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
            result.ShouldNotBeNull();
            //Assert.True(result != null);

        }

        [Theory]
        [InlineData(100)]
        public async Task GetTodoItemsByIdAsync_ShouldReturnNull_FailIfRequestIdNotFound(int id)
        {
            //Range - Expected
            var itemId = new GetItemQuery(id);

            //_itemRepositoryMock.Setup(x => x.GetTodoItemsById(itemId)).ReturnsAsync();

            //Act

            var result = await _sut.GetTodoItemsByIdAsync(itemId);
            //Assert
            result.ShouldBeEmpty();
            //Assert.True(result != null);

        }
    }
}
