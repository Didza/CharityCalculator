using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Features.EventTypes.Handlers.Commands;
using CharityCalculator.Application.Features.EventTypes.Requests.Commands;
using CharityCalculator.Application.Responses;
using CharityCalculator.Application.Tests.Mocks;
using CharityCalculator.Domain.Exceptions;
using Moq;
using Shouldly;
using Xunit;

namespace CharityCalculator.Application.Tests.EventTypes.Commands
{
    public class CreateEventTypeCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateEventTypeCommandHandler _handler;
        private readonly EventTypeDto _eventTypeDto;

        public CreateEventTypeCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _handler = new CreateEventTypeCommandHandler(_mockUow.Object);
            _eventTypeDto = new EventTypeDto
            {
                Name = "Test Event Type",
                MaximumDonationAmount = 100000,
                SupplementInPercentage = 5
            };
        }

        [Fact]
        public async Task ValidEventTypeAdded()
        {
            var result = await _handler.Handle(new CreateEventTypeCommand() { EventTypeDto = _eventTypeDto }, CancellationToken.None);

            var eventTypes = await _mockUow.Object.EventTypeRepository.GetAll();

            result.ShouldBeOfType<BaseResponse>();

            eventTypes.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InValidEventTypeAdded()
        {
             _eventTypeDto.SupplementInPercentage = -1;

            var result = Should.Throw<EventTypeDomainException>(() =>  _handler.Handle(new CreateEventTypeCommand() { EventTypeDto = _eventTypeDto }, CancellationToken.None));

            var leaveTypes = await _mockUow.Object.EventTypeRepository.GetAll();

            leaveTypes.Count.ShouldBe(3);

            result.ShouldBeOfType<EventTypeDomainException>();

        }
    }
}
