using Microsoft.AspNetCore.Mvc;
using SHAnalytics.Application.Features.Battles.Commands.Create;
using SHAnalytics.Application.Features.Battles.Queries.GetById;
using SHAnalytics.Application.Features.Battles.Queries.GetList;

namespace WebAPI.Controllers
{
    [Route("api/Battles")]
    [ApiController]
    public class BattleController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBattleCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetListBattleQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetByIdBattleQuery(id));
            return Ok(response);
        }
    }
}
