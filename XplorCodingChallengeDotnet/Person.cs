namespace XplorCodingChallengeDotnet;

public sealed class Person
{
    public ICollection<Wallet> Wallets { get; init; } = new List<Wallet>();

    public Person()
    {
    }

    public Person(ICollection<Wallet> wallets)
    {
        Wallets = wallets;
    }
}