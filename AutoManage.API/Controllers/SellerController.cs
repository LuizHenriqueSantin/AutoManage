using AutoManage.API.Controllers.Base;
using AutoManage.Application.DTOs.Seller;
using AutoManage.Application.Interfaces.Commands;
using AutoManage.Application.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AutoManage.API.Controllers
{
    [Route("api/Seller")]
    [ApiController]
    public class SellerController : BaseController
    {
        private readonly ISellerCommand _command;
        private readonly ISellerQuery _query;

        public SellerController(ISellerCommand command, ISellerQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SellerIn model)
        {
            await _command.Create(model);
            return CreatedResponse();
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromQuery] Guid id,  [FromBody] SellerIn model)
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

        [HttpPatch("UpdateSellerOfTheMonth")]
        public async Task<IActionResult> UpdateSellerOfTheMonth()
        {
            await _command.UpdateSellerOfTheMonth();
            return OkResponse();
        }

        [HttpGet("GetSellerWithTotalSalary")]
        public async Task<IActionResult> GetSellerWithTotalSalary([FromQuery] Guid id)
        {
            var result = await _query.GetSellerWithTotalSalary(id);
            return OkResponse(result);
        }
    }
}
