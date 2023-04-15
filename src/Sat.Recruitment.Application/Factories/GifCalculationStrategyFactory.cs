using Sat.Recruitment.Application.Bases;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Strategies;
using Sat.Recruitment.Entity.Enums;

namespace Sat.Recruitment.Application.Factories
{
	public class GifCalculationStrategyFactory : IGifCalculationStrategyFactory
	{
		public BaseGifCalculationStrategy CreateCalculationStrategy(UserType type)
		{
			BaseGifCalculationStrategy strategy;

			switch (type)
			{
				case UserType.Super:
					strategy = new SuperUserGifCalculationStrategy();
					break;
				case UserType.Premium:
					strategy = new PremiumUserGifCalculationStrategy();
					break;
				case UserType.Normal:
					strategy = new NormalUserBaseGifCalculationStrategy();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}

			return strategy;
		}
	}
}
