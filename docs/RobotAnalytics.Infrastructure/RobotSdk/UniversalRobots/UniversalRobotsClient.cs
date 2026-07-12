using RobotAnalytics.Contracts;
using RobotAnalytics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using RobotAnalytics.Contracts.Commands;
using System.Runtime.CompilerServices;

namespace RobotAnalytics.Infrastructure.RobotSdk.UniversalRobots;

public class UniversalRobotClient : IRobotClient
{
    private readonly UrScriptClient _scriptClient;

    public UniversalRobotClient(UrScriptClient urScriptClient)
    {
        _scriptClient =  urScriptClient;
    } 

    public Task ConnectAsync()
    {
        return _scriptClient.ConnectAsync();
    }

    public Task DisconnectAsync()
    {
        _scriptClient.Close();
        return Task.CompletedTask;
    }

    public Task<RobotState> GetStateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task MoveJAsync(MoveJCommand command)
    {
        await ConnectAsync();

        var script = ($@"
movej([{command.JointAngles[0]}, {command.JointAngles[1]}, {command.JointAngles[2]}, {command.JointAngles[3]}, {command.JointAngles[4]}, {command.JointAngles[5]}], a={command.Acceleration}, v={command.Velocity})
");
        await _scriptClient.SendAsync(script);
    }

    public IAsyncEnumerable<RobotState> StreamStateAsync()
    {
        throw new NotImplementedException();
    }
}
