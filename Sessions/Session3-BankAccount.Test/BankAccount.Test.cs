using System;
using Xunit;

namespace BankAccount.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Debit_Exception_when_frozen()
        {
            var testBankAccount = new BankAccount("TestCustomer", 10000);
            testBankAccount.FreezeAccount();
            Assert.Throws<Exception>(() => testBankAccount.Debit(10));
        }
        [Fact]
        public void Credit_Exception_when_frozen()
        {
            var testBankAccount = new BankAccount("TestCustomer", 10000);
            testBankAccount.FreezeAccount();
            Assert.Throws<Exception>(() => testBankAccount.Credit(10));
        }
        [Fact]
        public void Credit_Exception_when_underZero()
        {
            var testBankAccount = new BankAccount("TestCustomer", 10000);
            Assert.Throws<ArgumentOutOfRangeException>(() => testBankAccount.Credit(-10));
        }
        [Fact]
        public void Debit_Exception_when_underZero()
        {
            var testBankAccount = new BankAccount("TestCustomer", 10000);
            Assert.Throws<ArgumentOutOfRangeException>(() => testBankAccount.Debit(-10));
        }
        [Fact]
        public void Debit_Exception_when_biggerThanAccountBalance()
        {
            var testBankAccount = new BankAccount("TestCustomer", 10000);
            Assert.Throws<ArgumentOutOfRangeException>(() => testBankAccount.Debit(10000.1));
        }

    }
}
