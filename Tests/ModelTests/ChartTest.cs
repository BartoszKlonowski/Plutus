using App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.ModelTests
{
    [TestClass]
    public class ChartTest
    {
        [TestMethod]
        public void UpdateCorrectOnFirstElementTest()
        {
            var chart = new Chart();

            // This element should be added without any exception
            chart.Update( new Wallet(), 100 );
            Assert.AreEqual( 0, chart.Operations[0].ID );
            Assert.AreEqual( 100, chart.Operations[0].Amount );
        }


        [TestMethod]
        public void UpdateCorrectOnNextElementTest()
        {
            var chart = new Chart();
            chart.Update( new Wallet(), 100 );

            // This element should be added correctly with increased ID and amount
            chart.Update( new Wallet(), 200 );
            Assert.AreEqual( 1, chart.Operations[1].ID );
            Assert.AreEqual( 300, chart.Operations[1].Amount );
        }


        [TestMethod]
        public void UpdateCorrectOnNextNegativeElementTest()
        {
            var chart = new Chart();
            chart.Update( new Wallet(), 300 );

            // This element should be added correctly with increased ID and decreased amount
            chart.Update( new Wallet(), -50 );
            Assert.AreEqual( 1, chart.Operations[1].ID );
            Assert.AreEqual( 250, chart.Operations[1].Amount );
        }
    }
}
