using Sat.Recruitment.Application.Bases;
using Sat.Recruitment.Entity.Entities;

namespace Sat.Recruitment.Application.Strategies
{
    public class SuperUserGifCalculationStrategy : BaseGifCalculationStrategy
    {
        private const decimal GifPercentageGreaterHundred = 0.20M;

        public override void CalculateGifAmount(User user)
        {
            if (user.Balance > 100)
            {
                decimal giftAmount = user.Balance * GifPercentageGreaterHundred;
                user.Balance += giftAmount;
            }
        }
    }
}
