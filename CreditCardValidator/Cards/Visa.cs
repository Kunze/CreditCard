using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Cards
{
    public class Visa: CreditCard
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
        public override bool Validate(long number)
        {
            var textNumber = number.ToString();

            if ((textNumber.Length == 13 || textNumber.Length == 16) && (textNumber.StartsWith("4")))
            {
                return base.IsValid(number);
            }

            return false;
        }
    }
}