using AutoManage.API.Controllers.Base;
using AutoManage.Application.DTOs.Owner;
using AutoManage.Application.Interfaces.Commands;
using AutoManage.Application.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AutoManage.API.Controllers
{
    [Route("api/Owner")]
    [ApiController]
    public class OwnerController : BaseController
    {
        private readonly IOwnerCommand _command;
        private readonly IOwnerQuery _query;

        public OwnerController(IOwnerCommand command, IOwnerQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] OwnerIn model)
        {
            await _command.Create(model);
            return CreatedResponse();
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] OwnerIn model)
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

        [HttpGet("GetByCpfCnpj")]
        public async Task<IActionResult> GetByCpfCnpj([FromQuery] string cpfCnpj)
        {
            var result = await _query.GetByCpfCnpj(cpfCnpj);
            return OkResponse(result);
        }
    }
}
