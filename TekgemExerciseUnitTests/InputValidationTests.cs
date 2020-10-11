using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TekgemExercise;

namespace TekgemExerciseUnitTests
{
    /// <summary>
    /// Tests ensuring the program is not allowing invalid inputs.
    /// </summary>
    [TestClass]
    public class InputValidationTests
    {
        /// <summary>
        /// Ensure that valid inputs are being allowed.
        /// </summary>
        [TestMethod]
        public void TestValidInput()
        {
            bool result = Program.CheckInputValid("john-smi th");
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Ensure that symbols are not being allowed.
        /// </summary>
        [TestMethod]
        public void TestInvalidSymbolInput()
        {
            bool result = Program.CheckInputValid("anne wiliams!");
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Ensure that numbers are not being allowed
        /// </summary>
        [TestMethod]
        public void TestInvalidNumberInput()
        {
            bool result = Program.CheckInputValid("ann3 wili4ms");
            Assert.AreEqual(false, result);
        }
    }
}
