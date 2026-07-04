using RobotAnalytics.Domain;
namespace RobotAnalytics.Contracts;

public interface IRobotDataProvider
{
    RobotState GetState();
}