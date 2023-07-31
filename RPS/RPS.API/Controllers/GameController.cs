using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPS.API.Models;
using RPS.Application.Commands.Games;
using RPS.Application.Queries.Games;
using RPS.Application.ViewModel;
using RPS.Contracts.Models;

namespace RPS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateGameResult), StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateGameResult>> CreateGameAsync([FromQuery] string userName, CancellationToken cancellationToken)
        {
            var game = await _mediator.Send(new CreateGameCommand(userName), cancellationToken).ConfigureAwait(false);

            return Ok(new CreateGameResult { GameId = game.Id, FirstUserId = game.FirstUser.Id });
        }

        [HttpPut("{gameId:int}/join/{userName}")]
        [ProducesResponseType(typeof(JoinToGameResult), StatusCodes.Status200OK)]
        public async Task<ActionResult<JoinToGameResult>> JoinUserAsync(int gameId, string userName, CancellationToken cancellationToken)
        {
            var game = await _mediator.Send(
                new JoinToGameCommand(
                    new JoinViewModel { GameId = gameId, SecondUserName = userName }),
                cancellationToken).ConfigureAwait(false);

            return Ok(new JoinToGameResult { SecondUserId = game.SecondUser.Id });
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [Route("{gameId:int}/user/{userId:int}/{turn:rpsType}")]
        public async Task<ActionResult<bool>> TurnUserAsync(int gameId, int userId, RPSType turn, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(
                new UserStepCommand(
                    new UserStepViewModel { GameId = gameId, UserId = userId, Turn = turn}), 
                cancellationToken).ConfigureAwait(false));
        }

        [HttpGet("{gameId:int}/stat")]
        [ProducesResponseType(typeof(GameStatisticViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<GameStatisticViewModel>> StatisticAsync(int gameId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetGameRequest(gameId), cancellationToken).ConfigureAwait(false));
        }
    }
}
