using CreditCardValidator.Exceptions;
using System;
using System.Text.RegularExpressions;
using CreditCardValidator.Services;

namespace Teste_LeanWork
{
    class Program
    {
        const string AllExceptNumbers = "[^0-9.]";

        static void Main(string[] args)
        {
            var creditCardValidator = new CreditCardValidatorService();

            string input;

            WriteANumber();

            while ((input = Console.ReadLine()) != string.Empty)
            {
                long cardNumber;
                if (!long.TryParse(Regex.Replace(input, AllExceptNumbers, ""), out cardNumber))
                {
                    Console.WriteLine("Você deve informar somente números");

                    continue;
                }

                try
                {
                    var validator = creditCardValidator.GetValidator(cardNumber);

                    Write(string.Format("{0}: {1} (válido)", validator.CreditCardType, cardNumber));
                }
                catch (InvalidCreditCardException ex)
                {
                    Write(ex.Message);
                }
                catch (UnknowCreditCardException ex)
                {
                    Write(string.Format("Desconhecido: {0} (inválido)", cardNumber));
                }

                WriteANumber();
            }
        }

        private static void WriteANumber()
        {
            Console.WriteLine("Informe um número de cartão");
        }

        static void Write(string message)
        {
            var separator = new String('-', 50);

            Console.WriteLine(separator);
            Console.WriteLine(message);
            Console.WriteLine(separator);
        }
    }
}