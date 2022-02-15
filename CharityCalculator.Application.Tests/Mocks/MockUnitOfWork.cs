using Moq;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.Tests.Mocks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
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