using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Exceptions
{
    public class InvalidCreditCardException : Exception
    {
        public readonly string CreditCardType;
        public readonly long Number;

        public InvalidCreditCardException(string creditCardType, long number) :
            base(string.Format("{0}: {1} (inválido)", creditCardType, number))
        {
            CreditCardType = creditCardType;
            Number = number;
        }
    }
}