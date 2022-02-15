using System.Collections.Generic;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Domain.Models;
using Moq;

namespace CharityCalculator.Application.Tests.Mocks
{
    public static class MockEventTypeRepository
    {
        public static Mock<IEventTypeRepository> GetEventTypeRepository()
        {
            var eventTypes = new List<EventType>
            {
                new EventType("Sports", 5, 100000),
                new EventType("Political", 3, 100000),
                new EventType("Other", 0, 100000)
            };

            var mockRepo = new Mock<IEventTypeRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(eventTypes);

            mockRepo.Setup(r => r.Add(It.IsAny<EventType>())).ReturnsAsync((EventType eventType) =>
            {
                eventTypes.Add(eventType);
                return eventType;
            });

            return mockRepo;
        }
    }
}
