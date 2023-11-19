using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime");
           
        }

        [TestMethod]
        [DataRow(5)]
        public void MocTest(int value)
        {
            var paymentServiceMock = new Mock<PrimeService>();
            paymentServiceMock.Setup(p => p.IsPrime(5)).Returns(true);

            var result1 = _primeService.IsPrime(value);

            var result2 = paymentServiceMock.Object.IsPrime(value);

            Console.WriteLine("Hello World! " + result1 + " " + result2);




        }

        [TestMethod]
        public void Ping_invokes_DoSomething()
        {
            // ARRANGE
            var mock = new Mock<IFoo>();
            mock.Setup(p => p.DoSomething(It.IsAny<string>())).Returns(true);
            var sut = new Service(mock.Object);

            // ACT
            sut.Ping();

            // ASSERT
            mock.Verify(p => p.DoSomething("PING"), Times.Once());
        }
    }
}