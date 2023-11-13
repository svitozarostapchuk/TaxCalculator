using BusinessLogic.Services;
using Moq;

namespace Tests.BusinessLogic.Services
{
    public class TaxBandServiceTests
    {
        private TaxBandService _taxBandService;
        private Mock<ITaxBandRepository> _taxBandRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _taxBandRepositoryMock = new Mock<ITaxBandRepository>();
            _taxBandService = new TaxBandService(_taxBandRepositoryMock.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}