using Sat.Recruitment.Entity.Entities;

namespace Sat.Recruitment.Application.Interfaces
{
    public interface IUserService
	{
		Task<IReadOnlyList<User>> GetAllUsersAsync();
		Task<User> AddUserAsync(User user);
	}
}
