using Sat.Recruitment.Application.Bases;
using Sat.Recruitment.Entity.Entities;

namespace Sat.Recruitment.Application.Strategies
{
    public class NormalUserBaseGifCalculationStrategy : BaseGifCalculationStrategy
    {
        private const decimal GifPercentageGreaterHundred = 0.12M;
        private const decimal GifPercentageLessTen = 0.8M;

        public override void CalculateGifAmount(User user)
        {
            if (user.Balance > 100)
            {
                decimal giftAmount = user.Balance * GifPercentageGreaterHundred;
                user.Balance += giftAmount;
            }

            if (user.Balance is < 100 and > 10)
            {
                decimal giftAmount = user.Balance * GifPercentageLessTen;
                user.Balance += giftAmount;
            }
        }
    }
}
