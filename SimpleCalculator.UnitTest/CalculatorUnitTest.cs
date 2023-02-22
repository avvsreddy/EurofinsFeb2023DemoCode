using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleCalculator.DataAccess;
using SimpleCalculatorLibrary;

namespace SimpleCalculator.UnitTest
{

    //class MockCalculatorRepo : ICalculatorRepo
    //{
    //    public bool Save(string data)
    //    {
    //        return true;
    //    }
    //}


    [TestClass]
    public class CalculatorUnitTest
    {
        private Calculator target = null;
        Mock<ICalculatorRepo> mock = null;
        [TestInitialize]
        public void Init()
        {
            //ICalculatorRepo mock = new MockCalculatorRepo();
            mock = new Mock<ICalculatorRepo>();
            mock.Setup(m => m.Save("10+20=30")).Returns(true);

            target = new Calculator(mock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            target = null;
            mock = null;
        }


        [TestMethod]
        public void Sum_WithValidInput_ShouldGivesValidResult() // Test cases
        {
            // do not use conditional stmts
            // do not use iterative stmts
            // do not use try...catch stmts
            // write only simple stmts

            // AAA
            // A - Arrange
            int fno = 10;
            int sno = 20;
            int expected = 30;
            //Calculator target = new Calculator();
            // A - Act
            int actual = target.Sum(fno, sno);
            // A - Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NumberNegativeException))]
        public void Sum_WithNegativeInput_ShouldThrowsExp() // TEst case
        {
            //Calculator target = new Calculator();
            target.Sum(-1, -1);
            //
        }
        [TestMethod]
        [ExpectedException(typeof(OddNumberException))]
        public void Sum_WithOddInput_ThrowsExp()
        {
            target.Sum(1, 1);
        }

        [TestMethod]
        public void Sum_WithValidInput_ShouldCallSaveMethod()
        {
            target.Sum(10, 20);
            mock.Verify(m => m.Save("10+20=30"), Times.Once());

        }
    }
}
