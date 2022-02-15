using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Features.EventTypes.Handlers.Commands;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;

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
    }
}
