using Microsoft.AspNetCore.Mvc;
using RobotAnalytics.Application.UseCases;
using RobotAnalytics.Contracts.Commands;

namespace RobotAnalytics.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RobotController : ControllerBase
{
    private readonly MoveRobotUseCase _moveRobotUseCase;

    public RobotController(MoveRobotUseCase moveRobotUseCase)
    {
        _moveRobotUseCase = moveRobotUseCase;
    }

    [HttpPost("movej")]
    public Task MoveJAsync([FromBody] MoveJCommand moveJCommand)
    {
        return _moveRobotUseCase.ExecuteAsync(moveJCommand);
    }
}