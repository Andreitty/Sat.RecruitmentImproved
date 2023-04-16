using System.Linq.Expressions;
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
		private UserService _userService;
		private Mock<IBaseRepository<User, int>> _mockRepository;
		private Mock<IGifCalculationStrategyFactory> _mockStrategyFactory;
		private Mock<ILogger<UserService>> _mockLogger;

		[TestInitialize]
		public void UserServiceTestInitialize()
		{
			_mockRepository = new Mock<IBaseRepository<User, int>>();
			_mockStrategyFactory = new Mock<IGifCalculationStrategyFactory>();
			_mockLogger = new Mock<ILogger<UserService>>();
			_userService = new UserService(_mockRepository.Object, _mockStrategyFactory.Object, _mockLogger.Object);
		}

		[TestMethod]
		public async Task AddUserAsync_WithAddressAndNameDuplicated_ThrowsExceptionAsync()
		{
			// Arrange
			var user = new User
			{
				Address = "Caracas-Venezuela",
				Name = "Andreidy Rosa"
			};
			_mockRepository.Setup(mr => 
				mr.ListAsync(It.IsAny<Expression<Func<User, bool>>>()))
				.Returns(new Task<IReadOnlyList<User>>(() => new User[1]));
			
			await _userService.AddUserAsync(user);

			// Act and Assert
			await Assert.ThrowsExceptionAsync<Exception>(() => _userService.AddUserAsync(user));
		}

		[TestMethod]
		public async Task GetAllUsersAsync_ReturnsEmptyList()
		{
			// Arrange
			_mockRepository.Setup(mr => mr.ListAsync())
				.Returns(new Task<IReadOnlyList<User>>(() => new User[1]));

			// Act
			var result = await _userService.GetAllUsersAsync();

			//Assert
			Assert.AreEqual(1, result.Count);
		}
	}
}