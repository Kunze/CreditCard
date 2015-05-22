namespace CreditCardValidator.Cards
{
    public sealed class AMEX: CreditCard
    {
        public AMEX()
            : base("AMEX")
        {

        }

        /// <summary>
        /// Valida se o número é válido de acordo com as regras do cartão AMEX
        /// </summary>
        /// <param name="number">Número a ser verificado</param>
        /// <returns>Verdadeiro se for válido</returns>
        protected internal override bool IsValid(long number)
        {
            var textNumber = number.ToString();
            
            if (textNumber.Length < 2)
            {
                return false;
            }

            var twoFirstNumbers = int.Parse(textNumber.Substring(0, 2));

            return ((textNumber.Length == 15) && (twoFirstNumbers == 34 || twoFirstNumbers == 37));
        }
    }
}