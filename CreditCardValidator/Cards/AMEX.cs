namespace CreditCardValidator.Cards
{
    public class AMEX: CreditCard
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
        public override bool Validate(long number)
        {
            var textNumber = number.ToString();
            
            if (textNumber.Length < 2)
            {
                return false;
            }

            var twoFirstNumbers = int.Parse(textNumber.Substring(0, 2));

            if ((textNumber.Length == 15) && (twoFirstNumbers == 34 || twoFirstNumbers == 37))
            {
                return base.IsValid(number);
            }

            return false;
        }
    }
}