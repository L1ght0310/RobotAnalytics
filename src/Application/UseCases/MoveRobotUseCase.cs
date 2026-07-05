using RobotAnalytics.Contracts;
using RobotAnalytics.Contracts.Commands;

namespace RobotAnalytics.Application.UseCases;

public class MoveRobotUseCase
{
    private readonly IRobotClient _robotClient;

    public MoveRobotUseCase(IRobotClient robotClient)
    {
        _robotClient = robotClient;

    }

    public Task ExecuteAsync(MoveJCommand moveJCommand)
    {
        return _robotClient.MoveJAsync(moveJCommand);
    }
}
