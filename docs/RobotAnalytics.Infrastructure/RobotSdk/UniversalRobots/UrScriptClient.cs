using RobotAnalytics.Contracts.Commands;
using System.Net.Sockets;
using System.Text;

public class UrScriptClient
{
    private TcpClient _client;
    private NetworkStream _stream;

    private readonly string _ip = "127.0.0.1";
    private readonly int _port = 30002;

    public async Task ConnectAsync()
    {
        _client = new TcpClient();
        await _client.ConnectAsync(_ip, _port);
        _stream = _client.GetStream();
    }

    public async Task SendAsync(string script)
    {
        if (_stream == null)
            throw new Exception("Not connected");

        var data = Encoding.ASCII.GetBytes(script + "\n");
        await _stream.WriteAsync(data, 0, data.Length);
    }

    public void Close()
    {
        _stream?.Close();
        _client?.Close();
    }
}