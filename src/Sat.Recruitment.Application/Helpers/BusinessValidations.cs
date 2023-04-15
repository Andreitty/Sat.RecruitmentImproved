using Sat.Recruitment.Entity.Entities;
using Sat.Recruitment.Infrastructure.Interfaces.Bases;

namespace Sat.Recruitment.Application.Helpers
{
	public class BusinessValidations
	{
		public static bool IsNameAndAddressDuplicated(IBaseRepository<User, int> repository, User user)
		{
			var isNameDuplicated = repository.
				ListAsync(ur => ur.Name.ToLower() == user.Name.ToLower()).Result.Any();

			if (isNameDuplicated)
			{
				var isAddressDuplicated = repository.
					ListAsync(ur => ur.Address.ToLower() == user.Address.ToLower()).Result.Any();
				return isAddressDuplicated;
			}

			return false;
		}

		public static bool IsBalanceGreaterThanZero(User user)
		{
			return user.Balance > 0;
		}
	}
}
