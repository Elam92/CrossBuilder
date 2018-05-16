using Cross;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrossUnitTests
{
    [TestClass]
    public class IntValidatorTests
    {
        [TestMethod]
        public void Validate_WithLetters_ReturnFalse()
        {
            IntValidator validator = new IntValidator();

            bool result = validator.Validate("ABC");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_WithFloat_ReturnFalse()
        {
            IntValidator validator = new IntValidator();

            bool result = validator.Validate("12.5");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_WithNegativeNumber_ReturnFalse()
        {
            IntValidator validator = new IntValidator();

            bool result = validator.Validate("-1");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_Empty_ReturnFalse()
        {
            IntValidator validator = new IntValidator();

            bool result = validator.Validate("");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_WithOverFlow_ReturnFalse()
        {
            IntValidator validator = new IntValidator();

            bool result = validator.Validate("9999999999999999999999");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_WithOverFlowNegative_ReturnFalse()
        {
            IntValidator validator = new IntValidator();

            bool result = validator.Validate("-9999999999999999999999");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_WithInteger_ReturnTrue()
        {
            IntValidator validator = new IntValidator();

            bool result = validator.Validate("1");

            Assert.AreEqual(true, result);
        }
    }
}
