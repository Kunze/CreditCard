using CreditCardValidator.Cards.Interfaces;
using CreditCardValidator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Cards
{
    public abstract class CreditCard : ICreditCardValidator
    {
        private readonly string _creditCardName;

        public CreditCard(string creditCardName)
        {
            _creditCardName = creditCardName;
        }

        string ICreditCardValidator.CreditCardType
        {
            get { return _creditCardName; }
        }

        public abstract bool Validate(long number);

        /// <summary>
        /// Verifica se o número é par
        /// </summary>
        /// <param name="number">Número a ser testado</param>
        /// <returns>Verdadeiro se for par</returns>
        private bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// 1 - Tome uma sequência de números inteiros positivos e a inverta.
        /// </summary>
        /// <param name="number">Número a ser invertido</param>
        /// <returns>Lista com os números invertidos</returns>
        private List<int> ReverseToList(long number)
        {
            return number.ToString().Reverse().Select((n) => int.Parse(n.ToString())).ToList();
        }

        /// <summary>
        /// 2 - Começando pelo segundo número, dobre o valor de cada número de forma alternada ("24145... = "28185...).
        /// </summary>
        /// <param name="invertedNumber">Números invertidos</param>
        /// <returns>Lista com os valores pares multiplicados por 2 e diminuidos 9</returns>
        private List<int> DoubleEvenIndex(List<int> invertedNumber)
        {
            var doubleValues = new List<int>();
            for (int i = 0; i < invertedNumber.Count; i++)
            {
                var number = invertedNumber[i];

                if (IsEven(i + 1))
                {
                    var doubledNumber = invertedNumber[i] * 2;

                    /*
                        Para dígitos maiores que 9 será necessário que some cada dígito ("10", 1 + 0 = 1) ou subtraia por 9 ("10", 10 - 9 = 1)
                    */
                    number = (doubledNumber > 9 ? doubledNumber - 9 : doubledNumber);
                }

                doubleValues.Add(number);
            }

            return doubleValues;
        }

        /// <summary>
        /// Some todos os números da sequência.
        /// </summary>
        /// <param name="values">Lista de valores a serem somados</param>
        /// <returns>Soma de todos os números</returns>
        public int SumValues(IEnumerable<int> values)
        {
            return values.Aggregate((sum, next) => sum += next);
        }

        /// <summary>
        /// Verifica se um número de cartão é válido seguindo a regra http://rosettacode.org/wiki/Luhn_test_of_credit_card_numbers
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns>Verdadeiro se for válido</returns>
        protected bool IsValid(long cardNumber)
        {
             /*
                Se o total for múltiplo de 10, o número é válido.
             */
            if ((SumValues(DoubleEvenIndex(ReverseToList(cardNumber))) % 10 == 0))
            {
                return true;
            }

            throw new InvalidCreditCardException(_creditCardName, cardNumber);
        }
    }
}