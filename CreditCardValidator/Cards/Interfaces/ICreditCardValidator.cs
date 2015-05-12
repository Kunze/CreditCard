using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreditCardValidator.Cards.Interfaces
{
    public interface ICreditCardValidator
    {
        string CreditCardType { get; }
        bool Validate(long number);
    }
}