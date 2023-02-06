using NUnit.Framework;
using XplorCodingChallengeDotnet;
using XplorCodingChallengeDotnet.Cards;
using XplorCodingChallengeDotnet.InterestCalculators;

namespace XplorCodingChallengeDotnetUnitTests;

public sealed class Tests
{
    public const double VisaInterest = 0.10;
    public const double McInterest = 0.05;
    public const double DiscoverInterest = 0.01;

    [Test]
    public void TestCaseOne()
    {
        var interestCalculator = new SimpleInterestCalculator();
        var person = new Person();
        var wallet = new Wallet();
        var visa = new VisaCard("4123-1234-1234-1234", "121", 100, VisaInterest);
        Assert.That(interestCalculator.CalculateInterest(visa) == 10); //interest per card

        var mc = new MastercardCard("5123-1234-1234-1234", "212", 100, McInterest);
        Assert.That(interestCalculator.CalculateInterest(mc) == 5); //interest per card

        var discover = new DiscoverCard("6011-1234-1234-1234", "313", 100, DiscoverInterest);
        Assert.That(interestCalculator.CalculateInterest(discover) == 1); //interest per card

        wallet.Cards.Add(visa);
        wallet.Cards.Add(mc);
        wallet.Cards.Add(discover);
        person.Wallets.Add(wallet);

        Assert.That(interestCalculator.CalculateInterest(person.Wallets) == 16); //interest per person
    }

    [Test]
    public void TestCaseTwo()
    {
        var interestCalculator = new SimpleInterestCalculator();
        var person = new Person();
        var walletOne = new Wallet();
        walletOne.Cards.Add(new VisaCard("4123-2345-2345-2345", "212", 100, VisaInterest));
        walletOne.Cards.Add(new DiscoverCard("6011-2345-2345-2345", "312", 100, DiscoverInterest));
        Assert.That(interestCalculator.CalculateInterest(walletOne) == 11); //interest per wallet

        var walletTwo = new Wallet();
        walletTwo.Cards.Add(new MastercardCard("5234-2345-2345-2345", "313", 100, McInterest));
        Assert.That(interestCalculator.CalculateInterest(walletTwo) == 5); //interest per wallet

        person.Wallets.Add(walletOne);
        person.Wallets.Add(walletTwo);

        Assert.That(interestCalculator.CalculateInterest(person.Wallets) == 16); //interest per person
    }

    [Test]
    public void TestCaseThree()
    {
        var interestCalculator = new SimpleInterestCalculator();
        var personOne = new Person();
        var walletOne = new Wallet();
        walletOne.Cards.Add(new VisaCard("4345-3456-3456-3456", "314", 100, VisaInterest));
        walletOne.Cards.Add(new MastercardCard("5345-3456-3456-3456", "314", 100, McInterest));
        personOne.Wallets.Add(walletOne);
        Assert.Multiple(() =>
        {
            Assert.That(interestCalculator.CalculateInterest(walletOne) == 15); //interest per wallet
            Assert.That(interestCalculator.CalculateInterest(personOne.Wallets) == 15); //interest per person
        });
        var personTwo = new Person();
        var walletTwo = new Wallet();
        walletTwo.Cards.Add(new VisaCard("4456-4567-4567-4567", "315", 100, VisaInterest));
        walletTwo.Cards.Add(new MastercardCard("5456-4567-4567-4567", "316", 100, McInterest));
        personTwo.Wallets.Add(walletTwo);
        Assert.Multiple(() =>
        {
            Assert.That(interestCalculator.CalculateInterest(walletTwo) == 15); //interest per wallet
            Assert.That(interestCalculator.CalculateInterest(personTwo.Wallets) == 15); //interest per person
        });
    }

    [Test]
    public void TestInvalidCardNumbers()
    {
        //null card number
        Assert.Throws<ArgumentException>(() => new VisaCard(null, "123", 100, VisaInterest));
        Assert.Throws<ArgumentException>(() => new MastercardCard(null, "123", 100, McInterest));
        Assert.Throws<ArgumentException>(() => new DiscoverCard(null, "123", 100, DiscoverInterest));

        //wrong starting digits
        Assert.Throws<ArgumentException>(() => new VisaCard("0000-0000-0000-0000", "123", 100, VisaInterest));
        Assert.Throws<ArgumentException>(() => new MastercardCard("0000-0000-0000-0000", "123", 100, McInterest)); 
        Assert.Throws<ArgumentException>(() => new DiscoverCard("0000-0000-0000-0000", "123", 100, DiscoverInterest));

        //wrong number of digits
        Assert.Throws<ArgumentException>(() => new VisaCard("4123-1234-1234", "123", 100, VisaInterest));
        Assert.Throws<ArgumentException>(() => new MastercardCard("5123-1234-1234", "123", 100, McInterest));
        Assert.Throws<ArgumentException>(() => new DiscoverCard("6011-1234-1234", "123", 100, DiscoverInterest));
    }

    [Test]
    public void TestInvalidCvcNumbers()
    {
        //null cvc
        Assert.Throws<ArgumentException>(() => new VisaCard("4123-1234-1234-1234", null, 100, VisaInterest));
        Assert.Throws<ArgumentException>(() => new MastercardCard("5123-1234-1234-1234", null, 100, McInterest));
        Assert.Throws<ArgumentException>(() => new DiscoverCard("6011-1234-1234-1234", null, 100, DiscoverInterest));

        //non-digit cvc
        Assert.Throws<ArgumentException>(() => new VisaCard("4123-1234-1234-1234", "123F", 100, VisaInterest));
        Assert.Throws<ArgumentException>(() => new MastercardCard("5123-1234-1234-1234", "L234", 100, McInterest));
        Assert.Throws<ArgumentException>(() => new DiscoverCard("6011-1234-1234-1234", "O123", 100, DiscoverInterest));

        //wrong number digits in cvc
        Assert.Throws<ArgumentException>(() => new VisaCard("4123-1234-1234-1234", "1234", 100, VisaInterest));
        Assert.Throws<ArgumentException>(() => new MastercardCard("5123-1234-1234-1234", "1234", 100, McInterest));
        Assert.Throws<ArgumentException>(() => new DiscoverCard("6011-1234-1234-1234", "1234", 100, DiscoverInterest));
    }
}