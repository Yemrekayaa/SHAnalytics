﻿using Microsoft.AspNetCore.Mvc;
using SHAnalytics.Application.Features.InGames.Commands.Create;
using SHAnalytics.Application.Features.InGames.Commands.Update;
using SHAnalytics.Application.Features.InGames.Queries.GetById;
using SHAnalytics.Application.Features.InGames.Queries.GetList;
using SHAnalytics.Application.Features.InGames.Queries.GetListByPlayer;

namespace WebAPI.Controllers
{
    [Route("api/InGames")]
    [ApiController]
    public class InGameController : BaseController
    {

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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInGameByIdCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok();
        }

        [HttpGet("/api/players/{playerId}/InGames")]
        public async Task<IActionResult> GetListByPlayerId(int playerId)
        {
            var response = await Mediator.Send(new GetListByPlayerInGameQuery(playerId));
            return Ok(response);
        }

    }
}
