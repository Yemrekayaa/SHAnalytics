using Microsoft.AspNetCore.Mvc;
using SHAnalytics.Application.Features.Difficulties.Commands.Create;
using SHAnalytics.Application.Features.Difficulties.Queries.GetById;
using SHAnalytics.Application.Features.Difficulties.Queries.GetList;
using SHAnalytics.Application.Features.Difficulties.Queries.GetListBySession;

namespace WebAPI.Controllers
{
    [Route("api/Difficulties")]
    [ApiController]
    public class DifficultyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDifficultyCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetListDifficultyQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetByIdDifficultyQuery(id));
            return Ok(response);
        }

        [HttpGet("/api/Sessions/{sessionId}/Difficulties")]
        public async Task<IActionResult> GetListBySessionId(int sessionId)
        {
            var response = await Mediator.Send(new GetListBySessionDifficultyQuery(sessionId));
            return Ok(response);
        }
    }
}
