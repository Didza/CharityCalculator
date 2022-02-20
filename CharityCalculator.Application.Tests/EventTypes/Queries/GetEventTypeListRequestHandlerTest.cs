using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Features.EventTypes.Handlers.Queries;
using CharityCalculator.Application.Features.EventTypes.Requests;
using CharityCalculator.Application.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace CharityCalculator.Application.Tests.EventTypes.Queries
{
    public class GetEventTypeListRequestHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly GetEventTypeListRequestHandler _handler;
        public GetEventTypeListRequestHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _handler = new GetEventTypeListRequestHandler(_mockUow.Object);

        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        { 
            var result = await _handler.Handle(new GetEventTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<EventTypeDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
