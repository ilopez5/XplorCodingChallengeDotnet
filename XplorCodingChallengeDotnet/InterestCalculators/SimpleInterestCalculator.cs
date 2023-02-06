using XplorCodingChallengeDotnet.Cards;

namespace XplorCodingChallengeDotnet.InterestCalculators;

public sealed class SimpleInterestCalculator : IInterestCalculator
{
    public double CalculateInterest(Card card)
    {
        return card.InterestRate * card.Balance;
    }

    public double CalculateInterest(Wallet wallet)
    {
        return wallet.Cards.Select(CalculateInterest).Sum();
    }

    public double CalculateInterest(IEnumerable<Wallet> wallets)
    {
        return wallets.Sum(CalculateInterest);
    }
}