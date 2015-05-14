﻿namespace CreditCardValidator.Cards
{
    public class Discover : CreditCard
    {
        public Discover()
            : base("Discover")
        {

        }

        /// <summary>
        /// Valida se o número é válido de acordo com as regras do cartão Discover
        /// </summary>
        /// <param name="number">Número a ser verificado</param>
        /// <returns>Verdadeiro se for válido</returns>
        protected internal override bool IsValid(long number)
        {
            var textNumber = number.ToString();

            return ((textNumber.Length == 16) && (textNumber.StartsWith("6011")));
        }
    }
}
