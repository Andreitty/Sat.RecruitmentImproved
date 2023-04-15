using Sat.Recruitment.Application.Bases;
using Sat.Recruitment.Entity.Enums;

namespace Sat.Recruitment.Application.Interfaces
{
	public interface IGifCalculationStrategyFactory
	{
		BaseGifCalculationStrategy CreateCalculationStrategy(UserType type);
	}
}
