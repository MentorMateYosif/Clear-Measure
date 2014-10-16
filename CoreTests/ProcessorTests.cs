using System;
using System.Linq;

using Core;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTests
{
    [TestClass]
    public class ProcessorTests
    {
        #region Constants

        private const string FIZZ = "fizz";
        private const string BUZZ = "buzz";

        #endregion

        [TestMethod]
        public void HasFizzWordTest()
        {
            var result = Processor.Execute(1, 100);
            var condition = result.Contains(FIZZ);

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void HasNoFizzWordTest()
        {
            var result = Processor.Execute(1, 2);
            var condition = !result.Contains(FIZZ);

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void HasBuzzWordTest()
        {
            var result = Processor.Execute(1, 100);
            var condition = result.Contains(BUZZ);

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void HasNoBuzzWordTest()
        {
            var result = Processor.Execute(1, 4);
            var condition = !result.Contains(BUZZ);

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void HasFizzAndBuzzOnlyTest()
        {
            var result = Processor.Execute(15, 15);
            var condition = result.Contains(FIZZ) && result.Contains(BUZZ);

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void HasDigitsOnlyTest()
        {
            var result = Processor.Execute(1, 2);
            var resutParts = result.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            short digit = 0;
            var condition = resutParts.All(d => short.TryParse(d, out digit));

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void HasDigitsAndFizzWordOnlyTest()
        {
            var result = Processor.Execute(2, 3);
            var resultParts = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            short digit = 0;
            var condition = short.TryParse(resultParts[0], out digit) && resultParts[1] == FIZZ;

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void HasDigitsAndBuzzWordOnlyTest()
        {
            var result = Processor.Execute(4, 5);
            var resultParts = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            short digit = 0;
            var condition = short.TryParse(resultParts[0], out digit) && resultParts[1] == BUZZ;

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void InvalidInputValuesAreHandledTest()
        {
            var result = Processor.Execute(20, -100);
            var condition = string.IsNullOrWhiteSpace(result);

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void IntMinValueIsProducingErrorTest()
        {
            var result = Processor.Execute(short.MinValue, 100);
            var condition = !string.IsNullOrWhiteSpace(result);

            Assert.IsTrue(condition);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfMemoryException))]
        public void EndIndexMaxValueIsProducingExceptionTest()
        {
            Processor.Execute(1, short.MaxValue);
        }
    }
}