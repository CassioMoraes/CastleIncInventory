using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CastleIncInventory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerManufacturerController : ControllerBase
    {
        private readonly IComputerManufacturerRepository _computerManufactorerRepository;

        public ComputerManufacturerController(IComputerManufacturerRepository computerManufactorerRepository)
        {
            _computerManufactorerRepository = computerManufactorerRepository;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<ComputerManufacturer>> GetAll()
        {
            return await _computerManufactorerRepository.GetAllAsync();
        }
    }
}
