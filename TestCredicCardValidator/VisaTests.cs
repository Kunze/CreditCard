using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator.Cards;
using CreditCardValidator.Exceptions;
using System.Collections.Generic;

namespace TestCredicCardValidator
{
    [TestClass]
    public class VisaTests
    {
        [TestMethod]
        public void ShouldBeAValidVisa()
        {
            var validator = new Visa();

            var cards = new List<long>(){
                4929935320160705,
                4716260980914730,
                4532090150969103,
                4532667655657133,
                4539507507623615
            };

            cards.ForEach(i => Assert.IsTrue(validator.Validate(i)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardException))]
        public void ShouldBeAInvalidVisa()
        {
            var validator = new Visa();

            var cards = new List<long>(){
                4929935320160708,
                4716260980914738,
                4532090150969108,
                4532667655657138,
                4539507507623618
            };

            cards.ForEach(i => validator.Validate(i));
        }
    }
}