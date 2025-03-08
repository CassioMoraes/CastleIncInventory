using FluentValidation;
using CastleIncInventory.Domain.DataTransfer;
using CastleIncInventory.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CastleIncInventory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;
        private readonly IValidator<ComputerUpsert> _upsertValidator;

        public ComputerController(IComputerService computerService, IValidator<ComputerUpsert> upsertValidator)
        {
            _computerService = computerService;
            _upsertValidator = upsertValidator;
        }

        [HttpPost(Name = "Upsert")]
        public async Task<IActionResult> Upsert(ComputerUpsert computerUpsert)
        {
            var validationResult = _upsertValidator.Validate(computerUpsert);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var upsertResult = await _computerService.Upsert(computerUpsert);

            if (upsertResult.IsFailure)
                return BadRequest(upsertResult.Error);

            return Ok();
        }

        [HttpDelete]
        public void Delete([FromQuery] int computerId)
        {
            _computerService.Delete(computerId);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<ComputerUpsert>> GetAll()
        {
            return await _computerService.GetAll();
        }
    }
}
