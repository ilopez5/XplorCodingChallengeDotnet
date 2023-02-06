namespace XplorCodingChallengeDotnet.Cards;

public sealed class JcbCard : Card
{
    public new string Cvc
    {
        set
        {
            if (IsInvalidCardCvc(value))
                throw new ArgumentException($"Invalid JCB card cvc '{value}'");
            base.Cvc = value;
        }
    }

    public JcbCard(string? number, string? cvc, double balance, double interestRate)
        : base(number, cvc, balance, interestRate)
    {
        if (IsInvalidCardNumber(number))
            throw new ArgumentException($"Invalid JCB card number '{number}'");

        if (IsInvalidCardCvc(cvc))
            throw new ArgumentException($"Invalid JCB card cvc '{cvc}'");
    }

    public override bool IsInvalidCardNumber(string? number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return true;

        if (!number.StartsWith("35")) //naive validation to prove the point.
            return true;

        var cleaned = number.Replace("-", "");
        if (cleaned.Length != 16)
            return true;

        return !cleaned.All(char.IsDigit);
    }

    public override bool IsInvalidCardCvc(string? cvc)
    {
        if (string.IsNullOrWhiteSpace(cvc))
            return true;

        if (cvc.Length != 3)
            return true;

        return !cvc.All(char.IsDigit);
    }
}