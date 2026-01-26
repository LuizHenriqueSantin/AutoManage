using AutoManage.API.Controllers.Base;
using AutoManage.Application.DTOs.Sale;
using AutoManage.Application.Interfaces.Commands;
using AutoManage.Application.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AutoManage.API.Controllers
{
    [Route("api/Sale")]
    [ApiController]
    public class SaleController : BaseController
    {
        private readonly ISaleCommand _command;
        private readonly ISaleQuery _query;

        public SaleController(ISaleCommand command, ISaleQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SaleIn model)
        {
            await _command.Create(model);
            return CreatedResponse();
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] SaleIn model)
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

        [HttpGet("GetBySeller")]
        public async Task<IActionResult> GetBySeller([FromQuery] Guid sellerId, [FromQuery] int? year, [FromQuery] int? month)
        {
            var result = await _query.GetBySeller(sellerId, year, month);
            return OkResponse(result);
        }
    }
}
