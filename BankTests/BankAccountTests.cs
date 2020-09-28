using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningAmount = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount ba = new BankAccount("Mr. Bryan Walton", beginningAmount);

            // Act
            ba.Debit(debitAmount);
            double actual = ba.Balance;

            // Assert
            Assert.AreEqual(expected, actual, 0.001, "invalid balance");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningAmount = 11.99;
            double debitAmount = -100.00;
            BankAccount ba = new BankAccount("Mr. Bryan Walton", beginningAmount);

            // Act
            try
            {
                ba.Debit(debitAmount);
            } catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ba.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("Expected expection was not thrown");
        }

        [TestMethod]
        public void Debit_WhenAmountExceedsBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningAmount = 11.99;
            double debitAmount = 100.99;
            BankAccount ba = new BankAccount("Mr. Bryan Walton", beginningAmount);

            // Act
            try
            {
                ba.Debit(debitAmount);
            } catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ba.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("Expected expection was not thrown");
        }
    }
}
