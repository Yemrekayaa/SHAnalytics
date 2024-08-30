using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHAnalytics.Application.Features.Players.Commands.Create;
using SHAnalytics.Application.Features.Players.Queries.GetById;
using SHAnalytics.Application.Features.Players.Queries.GetList;

namespace WebAPI.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            CreatePlayerResponse response = await Mediator.Send(new CreatePlayerCommand());
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            IEnumerable<GetListPlayerResponse> response = await Mediator.Send(new GetListPlayerQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdPlayerResponse response = await Mediator.Send(new GetByIdPlayerQuery(id));
            return Ok(response);
        }

        [HttpGet("test2/{str}")]
        public async Task<IActionResult> GetById(string str)
        {
            return Ok(str);
        }
    }
}
