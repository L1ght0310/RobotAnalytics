using Microsoft.Extensions.Options;
using RobotAnalytics.Contracts.Commands;
using RobotAnalytics.Infrastructure.RobotSdk.UniversalRobots;
using System.Net.Sockets;
using System.Text;

public class UrScriptClient
{
    private TcpClient _client;
    private NetworkStream _stream;

    private readonly string _ip;
    private readonly int _port;

    public UrScriptClient(IOptions<UniversalRobotOptions> options)
    {
        _ip = options.Value.Ip;
        _port = options.Value.Port;
    }

    public async Task ConnectAsync()
    {
        _client = new TcpClient();
        await _client.ConnectAsync(_ip, _port);
        _stream = _client.GetStream();
    }

    public async Task SendAsync(string script)
    {
        if (_stream == null)
            throw new InvalidOperationException("Not connected");

        var data = Encoding.ASCII.GetBytes(script + "\n");
        await _stream.WriteAsync(data, 0, data.Length);
    }

    public void Close()
    {
        _stream?.Close();
        _client?.Close();
    }
}