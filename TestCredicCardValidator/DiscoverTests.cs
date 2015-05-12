using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator.Cards;
using System.Collections.Generic;
using CreditCardValidator.Exceptions;

namespace TestCredicCardValidator
{
    [TestClass]
    public class DiscoverTests
    {
        [TestMethod]
        public void ShouldBeAValidDiscover()
        {
            var validator = new Discover();

            var cards = new List<long>(){
                6011829395024009,
                6011433402437468,
                6011190421532881,
                6011603380558291
            };

            cards.ForEach(i => Assert.IsTrue(validator.Validate(i)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardException))]
        public void ShouldBeAInvalidDiscover()
        {
            var validator = new Discover();

            var cards = new List<long>(){
                6011829395024005,
                6011433402437465,
                6011190421532885,
                6011603380558295
            };

            cards.ForEach(i => validator.Validate(i));
        }
    }
}
