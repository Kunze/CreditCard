namespace CreditCardValidator.Cards
{
    public sealed class MasterCard : CreditCard
    {
        public MasterCard()
            : base("MasterCard")
        {

        }

        /// <summary>
        /// Valida se o número é válido de acordo com as regras do cartão MasterCard
        /// </summary>
        /// <param name="number">Número a ser verificado</param>
        /// <returns>Verdadeiro se for válido</returns>
        protected override bool IsValid(long number)
        {
            var textNumber = number.ToString();
            
            if (textNumber.Length < 2)
            {
                return false;
            }

            var twoFirstNumbers = int.Parse(textNumber.Substring(0, 2));

            return ((textNumber.Length == 16) && (twoFirstNumbers >= 51 && twoFirstNumbers <= 55));
        }
    }
}