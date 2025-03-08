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

        private OperacionalStatus GetOperacional(string status)
        {
            if (string.IsNullOrEmpty(status))
                return OperacionalStatus.New;

            var currentDescription = OperacionalStatus.New;

            foreach (var field in typeof(OperacionalStatus).GetFields())
            {
                if (field.GetCustomAttribute(typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == status)
                        currentDescription = (OperacionalStatus)field.GetValue(null);
                }
            }

            return currentDescription;
        }
    }
}
