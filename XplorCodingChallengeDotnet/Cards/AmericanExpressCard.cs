namespace XplorCodingChallengeDotnet.Cards;

public sealed class AmericanExpressCard : Card
{
    public new string Cvc
    {
        set
        {
            if (IsInvalidCardCvc(value))
                throw new ArgumentException($"Invalid AmericanExpress card cvc '{value}'");
            base.Cvc = value;
        }
    }

    public AmericanExpressCard(string? number, string? cvc, double balance, double interestRate)
        : base(number, cvc, balance, interestRate)
    {
        if (IsInvalidCardNumber(number))
            throw new ArgumentException($"Invalid AmericanExpress card number '{number}'");

        if (IsInvalidCardCvc(cvc))
            throw new ArgumentException($"Invalid AmericanExpress card cvc '{cvc}'");
    }

    public override bool IsInvalidCardNumber(string? number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return true;

        if (!number.StartsWith("34") && !number.StartsWith("37"))
            return true;

        var cleaned = number.Replace("-", "");
        if (cleaned.Length != 15)
            return true;

        return !cleaned.All(char.IsDigit);
    }

    public override bool IsInvalidCardCvc(string? cvc)
    {
        if (string.IsNullOrWhiteSpace(cvc))
            return true;

        if (cvc.Length != 4)
            return true;

        return !cvc.All(char.IsDigit);
    }
}