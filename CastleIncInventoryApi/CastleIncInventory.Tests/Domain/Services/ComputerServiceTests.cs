using CastleIncInventory.Domain.DataTransfer;
using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Domain.Repositories;
using CastleIncInventory.Domain.Services;
using CastleIncInventory.Shared;
using Moq;

namespace CastleIncInventory.Tests.Domain.Services
{
    public class ComputerServiceTests
    {
        private readonly Mock<IComputerRepository> _computerRepositoryMock;
        private readonly Mock<IComputerManufacturerRepository> _manufacturerRepositoryMock;
        private readonly Mock<IComputerStatusService> _statusServiceMock;
        private readonly ComputerService _computerService;

        public ComputerServiceTests()
        {
            _computerRepositoryMock = new Mock<IComputerRepository>();
            _manufacturerRepositoryMock = new Mock<IComputerManufacturerRepository>();
            _statusServiceMock = new Mock<IComputerStatusService>();

            _computerService = new ComputerService(_computerRepositoryMock.Object, _manufacturerRepositoryMock.Object, _statusServiceMock.Object);
        }

        [Fact]
        public async Task Upsert_NoManufacturerFound_ShouldReturnError()
        {
            _manufacturerRepositoryMock.Setup(m => m.Get(It.IsAny<uint>()));
            var result = await _computerService.Upsert(new ComputerUpsert());

            _manufacturerRepositoryMock.Verify(m => m.Get(It.IsAny<uint>()), Times.Once());
            Assert.False(result.IsSuccess);
            Assert.Equal("No manufactorer found for this Id", result.Error);
        }

        [Theory]
        [InlineData("RZL2THUS8V34", true)]
        [InlineData("RZL2323434", false)]
        public async Task Upsert_ManufacturerSerialNumberValidation(string serialNumber, bool expectedResult)
        {
            _manufacturerRepositoryMock.Setup(m => m.Get(It.IsAny<uint>()))
                .Returns(new ComputerManufacturer { Name = Manufactures.Apple, SerialRegex = "^[A-Z]{3}[C-Z0-9][1-9C-NP-RTY][A-Z0-9]{3}[A-Z0-9]{4}$" });
            _computerRepositoryMock.Setup(m => m.Upsert(It.IsAny<Computer>()))
                .Returns(new Computer { Id = 1 });
            _statusServiceMock.Setup(m => m.AddStatus(It.IsAny<Computer>(), It.IsAny<string>()))
                .ReturnsAsync(new Result());

            var computerUpsert = new ComputerUpsert { SerialNumber = serialNumber };

            var result = await _computerService.Upsert(computerUpsert);

            _manufacturerRepositoryMock.Verify(m => m.Get(It.IsAny<uint>()), Times.Once());
            Assert.Equal(expectedResult, result.IsSuccess);

            if (expectedResult is false)
                Assert.Equal($"Serial number: {serialNumber} does not match with the pattern defined by Apple", result.Error);
        }
    }
}