using Microsoft.Extensions.Logging;
using RobotAnalytics.Contracts;
using RobotAnalytics.Contracts.Commands;

namespace RobotAnalytics.Application.UseCases;

public class MoveRobotUseCase
{
    private readonly IRobotClient _robotClient;

    private readonly ILogger<MoveRobotUseCase> _logger;

    public MoveRobotUseCase(IRobotClient robotClient, ILogger<MoveRobotUseCase> logger)
    {
        _robotClient = robotClient;
        _logger = logger;

    }

    public Task ExecuteAsync(MoveJCommand moveJCommand)
    {
        return _robotClient.MoveJAsync(moveJCommand);
    }
}
