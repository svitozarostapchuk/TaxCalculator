using BusinessLogic.Services;
using Moq;
using TaxCalculator.Data;

namespace Tests.BusinessLogic.Services
{
    public class TaxBandServiceTests
    {
        private TaxBandService _taxBandService;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _taxBandService = new TaxBandService(_unitOfWorkMock.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}