using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHAnalytics.Application.Features.Sessions.Commands.Create;
using SHAnalytics.Application.Features.Sessions.Queries.GetById;
using SHAnalytics.Application.Features.Sessions.Queries.GetList;

namespace WebAPI.Controllers
{
    [Route("api/Sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSessionCommand command)
        {
            CreateSessionResponse response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            IEnumerable<GetListSessionResponse> response = await Mediator.Send(new GetListSessionQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdSessionResponse response = await Mediator.Send(new GetByIdSessionQuery(id));
            return Ok(response);
        }

        [HttpGet("test2/{str}")]
        public async Task<IActionResult> GetById(string str)
        {
            return Ok(str);
        }
    }
}
