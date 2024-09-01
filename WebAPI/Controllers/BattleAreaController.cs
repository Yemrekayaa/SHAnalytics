using Microsoft.AspNetCore.Mvc;
using SHAnalytics.Application.Features.BattleAreas.Commands.Create;
using SHAnalytics.Application.Features.BattleAreas.Queries.GetById;
using SHAnalytics.Application.Features.BattleAreas.Queries.GetList;

namespace WebAPI.Controllers
{
    [Route("api/BattleAreas")]
    [ApiController]
    public class BattleAreaController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBattleAreaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetListBattleAreaQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetByIdBattleAreaQuery(id));
            return Ok(response);
        }
    }
}
