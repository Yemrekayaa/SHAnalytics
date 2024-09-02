using Microsoft.AspNetCore.Mvc;
using SHAnalytics.Application.Features.CardOptions.Commands.Create;
using SHAnalytics.Application.Features.CardOptions.Commands.Update;
using SHAnalytics.Application.Features.CardOptions.Queries.GetById;
using SHAnalytics.Application.Features.CardOptions.Queries.GetList;
using SHAnalytics.Application.Features.CardOptions.Queries.GetListByBattle;
using SHAnalytics.Application.Features.CardOptions.Queries.GetListByBattleArea;
using SHAnalytics.Application.Features.CardOptions.Queries.GetListBySession;

namespace WebAPI.Controllers
{
    [Route("api/CardOptions")]
    [ApiController]
    public class CardOptionController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCardOptionCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetListCardOptionQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetByIdCardOptionQuery(id));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCardOptionByIdCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet("/api/Sessions/{sessionId}/CardOptions")]
        public async Task<IActionResult> GetListBySession(int sessionId)
        {
            var response = await Mediator.Send(new GetListBySessionCardOptionQuery(sessionId));
            return Ok(response);
        }

        [HttpGet("/api/BattleAreas/{battleAreaId}/CardOptions")]
        public async Task<IActionResult> GetListByBattleArea(int battleAreaId)
        {
            var response = await Mediator.Send(new GetListByBattleAreaCardOptionQuery(battleAreaId));
            return Ok(response);
        }

        [HttpGet("/api/Battles/{battleId}/CardOptions")]
        public async Task<IActionResult> GetListByBattle(int battleId)
        {
            var response = await Mediator.Send(new GetListByBattleCardOptionQuery(battleId));
            return Ok(response);
        }
    }
}
