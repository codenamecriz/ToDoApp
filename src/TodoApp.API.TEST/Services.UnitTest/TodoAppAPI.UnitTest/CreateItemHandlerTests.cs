using AutoMapper;
using FluentAssertions;
using Handlers.Commands;
using MediatR;
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
using Xunit;

namespace TodoAppServices.UnitTest.TodoAppAPI.UnitTest
{
    public class CreateItemHandlerTests
    {
        private readonly CreateItemHandler _sut;
        private readonly Mock<IItemCommandService> _itemCommandServiceMock = new Mock<IItemCommandService>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

   
        //private readonly Mock<IMediator> _mediatorMock =  new Mock<IMediator>();

        public CreateItemHandlerTests()
        {
            _sut = new CreateItemHandler(_itemCommandServiceMock.Object, _mapperMock.Object);
        }

        [Theory]
        [InlineData(0,"Bday","Party",EnumItemStatus.Done,1)]
        public async Task Handle_ShouldReturnId_WhenSuccessfulyCreated(
            int expeted,
            string name,
            string details,
            EnumItemStatus status,
            int todoId)
        {
            var response = new ResponseItemDto(1);
            var itemCommand = new CreateItemCommand();
            var itemRequest = new CreateItemRequest()
            {
                Name = name,
                Details = details,
                Status = status,
                TodoId = todoId
            };
            _mapperMock.Setup(x => x.Map<CreateItemCommand>(It.IsAny<CreateItemRequest>())).Returns(itemRequest);
            _itemCommandServiceMock.Setup(x => x.CreateItemAsync(itemRequest).Returns(response));
            var result = await _sut.Handle(itemRequest, new CancellationToken());

            //var result = await _sut.Handle(itemRequest);

            //var mediator = new Mock<IMediator>();
            //mediator.Setup(x => x.Send(itemRequest)).ReturnsAsync(() => null);

            ////Assert
            result.Should().NotBe(expeted);
            //int val = result.Id;
            //Assert.True(result.Id > 0);

        }

    }
}
