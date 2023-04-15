using Sat.Recruitment.Application.Bases;
using Sat.Recruitment.Entity.Entities;

namespace Sat.Recruitment.Application.Strategies
{
	public class PremiumUserGifCalculationStrategy : BaseGifCalculationStrategy
    {
	    public override void CalculateGifAmount(User user)
        {
            if (user.Balance > 100)
            {
                decimal giftAmount = user.Balance * 2;
                user.Balance += giftAmount;
            }
        }
    }
}
