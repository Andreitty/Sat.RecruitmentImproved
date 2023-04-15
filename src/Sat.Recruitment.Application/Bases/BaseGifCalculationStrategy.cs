using Sat.Recruitment.Entity.Entities;

namespace Sat.Recruitment.Application.Bases
{
	public abstract class BaseGifCalculationStrategy
	{
		public abstract void CalculateGifAmount(User user);
	}
}
