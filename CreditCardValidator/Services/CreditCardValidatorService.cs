using System.Collections.Generic;
using CreditCardValidator.Cards;
using CreditCardValidator.Cards.Interfaces;
using CreditCardValidator.Exceptions;

namespace CreditCardValidator.Services
{
    public class CreditCardValidatorService
    {
        private readonly List<ICreditCardValidator> _cards;

        public CreditCardValidatorService()
        {
            _cards = new List<ICreditCardValidator>
            {
                new MasterCard(),
                new AMEX(),
                new Visa(),
                new Discover()
            };
        }

        public ICreditCardValidator GetValidator(long cardNumber)
        {
            foreach (var validator in _cards)
            {
                if (validator.Validate(cardNumber))
                {
                    return validator;
                }
            }

            throw new UnknowCreditCardException();
        }
    }
}