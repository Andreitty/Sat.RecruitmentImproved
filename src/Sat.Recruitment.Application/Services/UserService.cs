using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Helpers;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Entity.Entities;
using Sat.Recruitment.Entity.Enums;
using Sat.Recruitment.Infrastructure.Interfaces.Bases;

namespace Sat.Recruitment.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IBaseRepository<User, int> _repository;
		private readonly IGifCalculationStrategyFactory _strategyFactory;
		private readonly ILogger<UserService> _logger;

		public UserService(IBaseRepository<User, int> repository,
			IGifCalculationStrategyFactory strategyFactory, ILogger<UserService> logger)
		{
			_repository = repository;
			_strategyFactory = strategyFactory;
			_logger = logger;
		}
		public async Task<IReadOnlyList<User>> GetAllUsersAsync()
		{
			return await _repository.ListAsync();
		}

		public async Task<User> AddUserAsync(User user)
		{
			if (BusinessValidations.IsNameAndAddressDuplicated(_repository, user))
			{
				_logger.LogError($"The user: {user.Name} is duplicated.");
				throw new Exception("There is an existing user with the provided name and address.");
			}

			if (!BusinessValidations.IsBalanceGreaterThanZero(user))
			{
				_logger.LogError($"The user: {user.Name} provided a balance less or equal to zero.");
				throw new Exception("Invalid balance. You must provided a balance greater than zero.");
			}

			if (!Enum.TryParse(user.UserType, true, out UserType userType))
				throw new Exception("Invalid UserType provided. Valid user types: Super, Premium, Normal");

			var gifCalculationStrategy = _strategyFactory.CreateCalculationStrategy(userType);

			gifCalculationStrategy.CalculateGifAmount(user);
			_logger.
				LogInformation($"The gif calculation strategy {gifCalculationStrategy.GetType()} was applied to user: {user.Name}");

			user.Email = EmailHelpers.NormalizeEmail(user.Email);

			var result = await _repository.AddAsync(user);

			_logger.LogInformation("User Created.");

			return result;
		}
	}
}

