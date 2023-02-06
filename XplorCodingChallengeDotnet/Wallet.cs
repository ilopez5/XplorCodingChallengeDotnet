using XplorCodingChallengeDotnet.Cards;

namespace XplorCodingChallengeDotnet;

public sealed class Wallet
{
    public ICollection<Card> Cards { get; init; } = new List<Card>();
    public Wallet()
    {
    }
    public Wallet(ICollection<Card> wallets)
    {
        Cards = wallets;
    }
}