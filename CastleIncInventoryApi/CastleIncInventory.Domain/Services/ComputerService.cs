using CastleIncInventory.Domain.DataTransfer;
using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Domain.Repositories;
using CastleIncInventory.Shared;

namespace CastleIncInventory.Domain.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IComputerRepository _computerRepository;
        private readonly IComputerManufacturerRepository _computerManufactorerRepository;
        private readonly IComputerStatusService _computerStatusService;

        public ComputerService(IComputerRepository computerRepository, IComputerManufacturerRepository computerManufactorerRepository, IComputerStatusService computerStatusService)
        {
            _computerRepository = computerRepository;
            _computerManufactorerRepository = computerManufactorerRepository;
            _computerStatusService = computerStatusService;
        }

        public async Task<IEnumerable<ComputerUpsert>> GetAll()
        {
            var computers = await _computerRepository.GetAllAsync();

            var computerUpsert = new List<ComputerUpsert>();

            foreach (var computer in computers)
                computerUpsert.Add(new ComputerUpsert(computer));

            return computerUpsert;
        }

        public async Task<Result> Upsert(ComputerUpsert computerUpsert)
        {
            var manufacturer = _computerManufactorerRepository.GetByName(computerUpsert.Manufacturer);

            if (manufacturer is null)
                return new Result(false, "No manufactorer found for this Id");

            var result = await ValidateComputerUpsert(computerUpsert, manufacturer);

            if (result.IsFailure)
                return result;

            computerUpsert.ManufacturerId = manufacturer.Id;
            var computer = computerUpsert.ToComputer();

            var upsertedComputer = _computerRepository.Upsert(computer);

            if (upsertedComputer is null)
                return new Result(false, "An error occurred when trying to create the computer");

            return await _computerStatusService.AddStatus(upsertedComputer, computerUpsert.OperacionalStatus);
        }

        public void Delete(int computerId)
        {
            _computerRepository.Delete(computerId);
        }

        private async Task<Result> ValidateComputerUpsert(ComputerUpsert computerUpsert, ComputerManufacturer manufacturer)
        {
            if (!manufacturer.IsSerialNumberValid(computerUpsert.SerialNumber))
                return new Result(false, $"Serial number: {computerUpsert.SerialNumber} does not match with the pattern defined by {manufacturer.Name}");

            var matchingSerialNumber = (await _computerRepository.GetAllAsync()).FirstOrDefault(c => c.SerialNumber.Equals(computerUpsert.SerialNumber));

            if (matchingSerialNumber is not null && matchingSerialNumber.Id != computerUpsert.Id)
                return new Result(false, $"Serial number: {computerUpsert.SerialNumber} already exists on the database");

            return new Result();
        }
    }
}
