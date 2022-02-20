using CharityCalculator.Application.Contracts.Persistence;
using Moq;

namespace CharityCalculator.Application.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockEventTypeRepo = MockEventTypeRepository.GetEventTypeRepository();

            mockUow.Setup(r => r.EventTypeRepository).Returns(mockEventTypeRepo.Object);

            return mockUow;
        }
    }
}