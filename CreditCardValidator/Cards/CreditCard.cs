using CreditCardValidator.Cards.Interfaces;
using CreditCardValidator.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardValidator.Cards
{
    public abstract class CreditCard : ICreditCardValidator
    {
        private readonly string _creditCardName;

        protected CreditCard(string creditCardName)
        {
            _creditCardName = creditCardName;
        }

        string ICreditCardValidator.CreditCardType
        {
            get { return _creditCardName; }
        }

        protected abstract bool IsValid(long number);

        /// <summary>
        /// Verifica se o número é par
        /// </summary>
        /// <param name="number">Número a ser testado</param>
        /// <returns>Verdadeiro se for par</returns>
        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// 1 - Tome uma sequência de números inteiros positivos e a inverta.
        /// </summary>
        /// <param name="number">Número a ser invertido</param>
        /// <returns>Lista com os números invertidos</returns>
        private static IReadOnlyList<int> ReverseNumbers(long number)
        {
            return number.ToString().Reverse().Select(n => int.Parse(n.ToString())).ToList();
        }

        /// <summary>
        /// Some todos os números da sequência.
        /// </summary>
        /// <param name="values">Lista de valores a serem somados</param>
        /// <returns>Soma de todos os números</returns>
        private static int SumValues(IEnumerable<int> values)
        {
            return values.Aggregate((sum, next) => sum + next);
        }

        /// <summary>
        // 2 - Começando pelo segundo número, dobre o valor de cada número de forma alternada ("24145... = "28185...).
        /// </summary>
        /// <param name="reversedNumbers">Números que seram dobrados</param>
        /// <returns>Lista com os números dobrados</returns>
        private static IEnumerable<int> Double(IReadOnlyList<int> reversedNumbers)
        {
            for (var i = 0; i < reversedNumbers.Count; i++)
            {
                var reversedNumber = reversedNumbers[i];

                if (IsEven(i + 1))
                {
                    var doubledNumber = reversedNumbers[i] * 2;

                    // Para dígitos maiores que 9 será necessário que some cada dígito ("10", 1 + 0 = 1) ou subtraia por 9 ("10", 10 - 9 = 1)
                    reversedNumber = (doubledNumber > 9 ? doubledNumber - 9 : doubledNumber);
                }

                yield return reversedNumber;
            }
        }
        /// <summary>
        /// Verifica se um número de cartão é válido seguindo a regra http://rosettacode.org/wiki/Luhn_test_of_credit_card_numbers
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns>Verdadeiro se for válido</returns>
        public bool Validate(long cardNumber)
        {
            if (!IsValid(cardNumber))
            {
                return false;
            }

            var reversedNumbers = ReverseNumbers(cardNumber);
            var reversedNumbersWithDoubledValues = Double(reversedNumbers);

            // Se o total for múltiplo de 10, o número é válido.
            if (SumValues(reversedNumbersWithDoubledValues) % 10 == 0)
            {
                return true;
            }

            throw new InvalidCreditCardException(_creditCardName, cardNumber);
        }
    }
}