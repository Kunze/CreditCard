namespace CreditCardValidator.Cards.Interfaces
{
    public interface ICreditCardValidator
    {
        string CreditCardType { get; }
        bool Validate(long number);
    }
}