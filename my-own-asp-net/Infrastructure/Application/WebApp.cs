using System.Net;
using System.Net.Sockets;
using System.Text;

namespace my_own_asp_net.Infrastructure.Application;

public class WebApp
{
    private readonly IDictionary<string, IRequestHandler> _handlers = new Dictionary<string, IRequestHandler>();

    /// <summary>
    ///     A bit of magic to start listening to port 80
    /// </summary>
    public void Start()
    {
        TcpListener listener = new(IPAddress.Any, 80);
        listener.Start();

        Console.WriteLine("Listening on port 80...");

        while (true)
        {
            using var client = listener.AcceptTcpClient();
            using var stream = client.GetStream();
            var buffer = new byte[1024];
            var bytesRead = stream.Read(buffer, 0, buffer.Length);
            var request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine("Request received:");
            Console.WriteLine(request);
            var methodLine = request.Split(Environment.NewLine).First();
            var url = methodLine.Split(' ')[1];
            var response = ProcessRequest(url);
            Console.WriteLine("Response sent:");
            Console.WriteLine(response);

            var responseBytes = Encoding.UTF8.GetBytes(response);
            stream.Write(responseBytes, 0, responseBytes.Length);
        }
        // ReSharper disable once FunctionNeverReturns this function should only stop when the program exits
    }

    private string ProcessRequest(string url)
    {
        Console.WriteLine($"Processing request for {url}");
        _handlers.TryGetValue(url, out var handler);
        if (handler != null) return handler.Handle();
        Console.WriteLine("404 Not found");
        return string.Empty;
    }


    public void Map(string url, IRequestHandler handler)
    {
        _handlers.Add(url, handler);
    }
}