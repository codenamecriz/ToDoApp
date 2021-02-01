using AutoMapper;
using FluentAssertions;
using Handlers.Commands;
using MediatR;
using Models.DTOs;
using Moq;
using NSubstitute;
using Services.Commands.Items;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Enum;
using TodoApp.API.Models;
using Xunit;

namespace TodoAppServices.UnitTest.TodoAppAPI.UnitTest
{
    public class CreateItemHandlerTests
    {
        private readonly CreateItemHandler _sut;
        private readonly Mock<IItemCommandService> _itemCommandServiceMock = new Mock<IItemCommandService>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public CreateItemHandlerTests()
        {
            _sut = new CreateItemHandler(_itemCommandServiceMock.Object, _mapperMock.Object);
        }

        [Theory]
        [InlineData(4)]
        public async Task Handle_CreateItemRequest_ShouldReturnId_WhenSuccessfulyCreated( int id )
        {
            var responseMock = new ResponseItemDto(id);
            //var itemCommand = new CreateItemCommand();
            //var itemRequest = new CreateItemRequest()
            //{
            //    Name = name,
            //    Details = details,
            //    Status = status,
            //    TodoId = todoId
            //};
            var itemRequest = CreateItemRequestSample();
            var itemDto = ItemCreateDtoSample();

            //var itemRepo = new Mock<IItemRepository>();
            //itemRepo.Setup(x => x.CreateItem(ItemModelDataSample()));

            _mapperMock.Setup(x => x.Map<CreateItemCommand>(It.IsAny<CreateItemRequest>())).Returns(itemRequest);
            _mapperMock.Setup(x => x.Map<ItemCreateDto>(It.IsIn<CreateItemCommand>(itemRequest))).Returns(itemDto);
            _mapperMock.Setup(x => x.Map(responseMock, itemDto)).Returns(itemDto);

            _itemCommandServiceMock.Setup(x => x.CreateItemAsync(itemRequest)).ReturnsAsync(responseMock);
            

            var result = await _sut.Handle(itemRequest, new CancellationToken());

            //var result = await _sut.Handle(itemRequest);

            //var mediator = new Mock<IMediator>();
            //mediator.Setup(x => x.Send(itemRequest)).ReturnsAsync(() => null);

            ////Assert
            result.Should().NotBeNull();
            //int val = result.Id;
            //Assert.True(result.Id > 0);

        }
        [Theory]
        [InlineData(0)]
        public async Task Handle_CreateItemRequest_ShouldBeFailed(int id)
        {
            var responseMock = new ResponseItemDto(id);
        
            var itemRequest = CreateItemRequestSample();

            _mapperMock.Setup(x => x.Map<CreateItemCommand>(It.IsAny<CreateItemRequest>())).Returns(itemRequest);

            _itemCommandServiceMock.Setup(x => x.CreateItemAsync(itemRequest)).ReturnsAsync(responseMock);

            var result = await _sut.Handle(itemRequest, new CancellationToken());

            ////Assert
            result.Should().BeNull();
     
        }
        public CreateItemRequest CreateItemRequestSample()
        {
            return new CreateItemRequest
            {
                //Id = 4,
                Name = "Happy",
                Details = "BirthDay",
                Status = EnumItemStatus.Done,
                TodoId = 1

            };
        }
        public ItemCreateDto ItemCreateDtoSample()
        {
            return new ItemCreateDto
            {
                Id = 4,
                Name = "Happy",
                Details = "BirthDay",
                Status = EnumItemStatus.Done,
                TodoId = 1

            };
        }

    }
}
