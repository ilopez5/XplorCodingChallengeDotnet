namespace XplorCodingChallengeDotnet.Cards;

public abstract class Card
{
    public string? Number { get; init; }
    public string? Cvc { get; set; }
    public double Balance { get; set; }
    public double InterestRate { get; set; }

    public Card(string? number, string? cvc, double balance, double interestRate)
    {
        Number = number;
        Cvc = cvc;
        Balance = balance;
        InterestRate = interestRate;
    }

    //See https://en.wikipedia.org/wiki/Payment_card_number for actual rules.
    //I kept the validations a bit naive as I think total coverage was not
    //the focus here.
    public abstract bool IsInvalidCardNumber(string number);

    //See https://www.legalstudies.com/faq/cvv-cvc-cid-credit-card-security-code-located-credit-card/
    //for actual rules (mainly on number of digits).
    public abstract bool IsInvalidCardCvc(string cvc);
}