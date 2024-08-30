using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHAnalytics.Application.Features.InGames.Commands.Create;
using SHAnalytics.Application.Features.InGames.Queries.GetById;
using SHAnalytics.Application.Features.InGames.Queries.GetList;

namespace WebAPI.Controllers
{
    [Route("api/InGames")]
    [ApiController]
    public class InGameController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateInGameCommand command)
        {
            CreateInGameResponse response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            IEnumerable<GetListInGameResponse> response = await Mediator.Send(new GetListInGameQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdInGameResponse response = await Mediator.Send(new GetByIdInGameQuery(id));
            return Ok(response);
        }

        //[HttpGet("/api/players/{playerId}/InGames")]
        //public async Task<IActionResult> GetListByPlayerId(int playerId)
        //{
        //    var response = await Mediator.Send(new GetListByPlayerInGameQuery(playerId));
        //    return Ok(response);
        //}

    }
}
