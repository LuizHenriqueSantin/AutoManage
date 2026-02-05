using AutoManage.API.Controllers.Base;
using AutoManage.Application.DTOs.Vehicle;
using AutoManage.Application.Interfaces.Commands;
using AutoManage.Application.Interfaces.Queries;
using AutoManage.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AutoManage.API.Controllers
{
    [Route("api/Vehicle")]
    [ApiController]
    public class VehicleController : BaseController
    {
        private readonly IVehicleCommand _command;
        private readonly IVehicleQuery _query;

        public VehicleController(IVehicleCommand command, IVehicleQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] VehicleIn model)
        {
            await _command.Create(model);
            return CreatedResponse();
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] VehicleIn model)
        {
            await _command.Update(id, model);
            return OkResponse();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _command.Delete(id);
            return NoContentResponse();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _query.GetAll();
            return OkResponse(result);
        }

        [HttpGet("GetBySystemVersion")]
        public async Task<IActionResult> GetBySystemVersion([FromQuery] SystemVersion version)
        {
            var result = await _query.GetBySystemVersion(version);
            return OkResponse(result);
        }

        [HttpGet("GetWithOwner")]
        public async Task<IActionResult> GetWithOwner([FromQuery] Guid id)
        {
            var result = await _query.GetWithOwner(id);
            return OkResponse(result);
        }

        [HttpPatch("UpdateByChassis")]
        public async Task<IActionResult> UpdateByChassis([FromBody] VehicleIn model)
        {
            await _command.UpdateByChassis(model);
            return OkResponse();
        }
    }
}
