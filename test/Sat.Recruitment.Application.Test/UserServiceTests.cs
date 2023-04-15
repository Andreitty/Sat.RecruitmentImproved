using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Entity.Entities;
using Sat.Recruitment.Infrastructure.Interfaces.Bases;

namespace Sat.Recruitment.Application.Test
{
	[TestClass]
	public class UserServiceTests
	{
		[TestMethod]
		public async Task GetAllUsersAsync_ReturnsEmptyList()
		{
			// Arrange
			var mockRepository = new Mock<IBaseRepository<User, int>>();
			var mockStrategyFactory = new Mock<IGifCalculationStrategyFactory>();
			var mockLogger = new Mock<ILogger<UserService>>();
			var userService = new UserService(mockRepository.Object, mockStrategyFactory.Object, mockLogger.Object);

			mockRepository.Setup(mr => mr.ListAsync())
				.Returns(new Task<IReadOnlyList<User>>(() => new User[1]));

			// Act
			var result = await userService.GetAllUsersAsync();

			//Assert
			Assert.AreEqual(1, result.Count);
		}
	}
}