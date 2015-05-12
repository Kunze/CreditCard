using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator;
using CreditCardValidator.Cards;
using System.Collections.Generic;
using CreditCardValidator.Exceptions;

namespace TestCredicCardValidator
{
    [TestClass]
    public class MasterCardTests
    {
        [TestMethod]
        public void ShouldBeAValidMasterCard()
        {
            var validator = new MasterCard();

            var cards = new List<long>(){
                5105105105105100,
                5183416396422061,
                5578274819456551,
                5375371893968553,
                5224309128575135
            };

            cards.ForEach(i => Assert.IsTrue(validator.Validate(i)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardException))]
        public void ShouldBeAInvalidMasterCard()
        {
            var validator = new MasterCard();

            var cards = new List<long>(){
                5105105105105108,
                5183416396422068,
                5578274819456558,
                5375371893968558,
                5224309128575138
            };

            cards.ForEach(i => Assert.IsTrue(validator.Validate(i)));
        }
    }
}