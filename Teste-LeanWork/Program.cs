using CreditCardValidator.Cards;
using CreditCardValidator.Cards.Interfaces;
using CreditCardValidator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Teste_LeanWork
{
    class Program
    {
        const string AllExceptNumbers = "[^0-9.]";

        static void Main(string[] args)
        {
            var validators = new List<ICreditCardValidator>();
            validators.Add(new MasterCard());
            validators.Add(new AMEX());
            validators.Add(new Visa());
            validators.Add(new Discover());

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

                var unknow = true;

                foreach (var validator in validators)
                {
                    try
                    {
                        if (validator.Validate(cardNumber))
                        {
                            Write(string.Format("{0}: {1} (válido)", validator.CreditCardType, cardNumber));
                            unknow = false;
                            break;
                        }
                    }
                    catch (InvalidCreditCardException ex)
                    {
                        Write(ex.Message);
                        unknow = false;
                        break;
                    }
                }

                if (unknow)
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
            Console.WriteLine(new String('-', 50));
            Console.WriteLine(message);

            Console.WriteLine(new String('-', 50));
        }
    }
}