using Microsoft.AspNetCore.Mvc;
using SHAnalytics.Application.Features.CardOptions.Commands.Create;
using SHAnalytics.Application.Features.CardOptions.Commands.Update;
using SHAnalytics.Application.Features.CardOptions.Queries.GetById;
using SHAnalytics.Application.Features.CardOptions.Queries.GetList;

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
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
