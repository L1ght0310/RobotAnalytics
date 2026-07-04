using RobotAnalytics.Contracts;

public class RobotService
{
    private readonly IRobotClient _client;

    public RobotService(IRobotClient client)
    {
        _client = client;
    }

    public Task MoveAsync(double[] joints)
        => _client.MoveJAsync(joints);
}