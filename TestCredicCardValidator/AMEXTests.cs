using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CreditCardValidator.Cards;
using CreditCardValidator.Exceptions;

namespace TestCredicCardValidator
{
    [TestClass]
    public class AMEXTests
    {
        [TestMethod]
        public void ShouldBeAValidAMEX()
        {
            var validator = new AMEX();

            var cards = new List<long>(){
                379164376523145,
                378750930126002,
                341713942350444,
                347109680640787
            };

            cards.ForEach(i => Assert.IsTrue(validator.Validate(i)));
        }

        [TestMethod]
        public void ShouldBeAInvalidAMEX()
        {
            var validator = new AMEX();

            var cards = new List<long>(){
                379164376523140,
                378750930126000,
                341713942350440,
                347109680640780
            };

            try
            {
                cards.ForEach(i =>
                {
                    validator.Validate(i);
                    Assert.Fail();
                });
            }
            catch (InvalidCreditCardException ex)
            {

            }
        }
    }
}