using App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.ModelTests
{
    [TestClass]
    public class WalletTest
    {
        [TestMethod]
        public void IncomeTest()
        {
            var wallet = new Wallet();
            wallet.Income( 50 );

            Assert.AreEqual( (decimal)50, wallet.Money );
        }


        [TestMethod]
        public void OutcomeTest()
        {
            var wallet = new Wallet();
            wallet.Outcome( 100 );

            Assert.AreEqual( (decimal)-100, wallet.Money );
        }


        [TestMethod]
        public void MoneyAsStringPresentationTest()
        {
            var wallet = new Wallet();
            wallet.Income( -12345 );

            Assert.AreEqual( "-12345 zł", wallet.ToString() );
        }
    }
}
