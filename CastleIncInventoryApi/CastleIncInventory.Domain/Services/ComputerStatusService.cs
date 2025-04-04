using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Domain.Repositories;
using CastleIncInventory.Shared;
using System.ComponentModel;
using System.Reflection;

namespace CastleIncInventory.Domain.Services
{
    public class ComputerStatusService : IComputerStatusService
    {
        private readonly IComputerStatusRepository _computerStatusRepository;

        public ComputerStatusService(IComputerStatusRepository computerStatusRepository)
        {
            _computerStatusRepository = computerStatusRepository;
        }

        public async Task<Result> AddStatus(Computer computer, string status)
        {
            var operationalStatus = GetOperacional(status);

            if (await _computerStatusRepository.IsStatusAlreadyAdded(computer.Id, operationalStatus))
                return new Result();

            var computerStatusId = await _computerStatusRepository.GetStatusId(operationalStatus);

            var newStatus = new LinkComputerStatus
            {
                AssignDate = DateTime.Now,
                ComputerId = computer.Id,
                ComputerStatusId = computerStatusId
            };

            _computerStatusRepository.AddStatus(newStatus);

            return new Result();
        }

        private OperationalStatus GetOperacional(string status)
        {
            if (string.IsNullOrEmpty(status))
                return OperationalStatus.New;

            var currentDescription = OperationalStatus.New;

            foreach (var field in typeof(OperationalStatus).GetFields())
            {
                if (field.GetCustomAttribute(typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == status)
                        currentDescription = (OperationalStatus)field.GetValue(null);
                }
            }

            return currentDescription;
        }
    }
}
