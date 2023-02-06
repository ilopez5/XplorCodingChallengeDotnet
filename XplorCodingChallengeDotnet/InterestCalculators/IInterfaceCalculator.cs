using XplorCodingChallengeDotnet.Cards;

namespace XplorCodingChallengeDotnet.InterestCalculators;

public interface IInterestCalculator
{
    public double CalculateInterest(Card card);
    public double CalculateInterest(Wallet card);
    public double CalculateInterest(IEnumerable<Wallet> wallets);
}