namespace CreditCardValidator.Cards
{
    public sealed class Visa : CreditCard
    {
        public Visa()
            : base("Visa")
        {

        }

        /// <summary>
        /// Valida se o número é válido de acordo com as regras do cartão VISA
        /// </summary>
        /// <param name="number">Número a ser verificado</param>
        /// <returns>Verdadeiro se for válido</returns>
        protected internal override bool IsValid(long number)
        {
            var textNumber = number.ToString();

            return ((textNumber.Length == 13 || textNumber.Length == 16) && (textNumber.StartsWith("4")));
        }
    }
}