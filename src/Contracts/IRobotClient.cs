using RobotAnalytics.Contracts.Commands;
using RobotAnalytics.Domain;
namespace RobotAnalytics.Contracts;

public interface IRobotClient
{
    Task ConnectAsync();
    Task DisconnectAsync();

    Task<RobotState> GetStateAsync();

    IAsyncEnumerable<RobotState> StreamStateAsync();

    Task MoveJAsync(MoveJCommand script);
}