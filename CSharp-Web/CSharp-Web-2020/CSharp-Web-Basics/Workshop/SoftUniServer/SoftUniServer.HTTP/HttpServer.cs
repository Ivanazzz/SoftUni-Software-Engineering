namespace SoftUniServer.HTTP
{
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class HttpServer : IHttpServer
    {
        IDictionary<string, Func<HttpRequest, HttpResponse>> routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }
        }

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port); // First parameter is equal to localhost
            tcpListener.Start();

            while (true)
            {
                // In the line below we use 'await' because we need the result to continue with the next line of code
                // Which is 'ProcessClientAsync'
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync(); // Waits and works with a client
                // We don't use 'await' before 'ProcessClientAsync' because we don't need the result
                // So we continue with the current client and also we can take new client in the line above
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            try
            {
                // Use 'using' when working with IDisposable
                using (NetworkStream stream = tcpClient.GetStream())
                {
                    // TODO: Research if there is a faster data structure for array of bytes
                    List<byte> data = new List<byte>();
                    int position = 0;
                    byte[] buffer = new byte[HttpConstants.BufferSize]; // Standard size for buffer is 4096

                    while (true)
                    {
                        int count = await stream.ReadAsync(buffer, position, buffer.Length);
                        position += count;

                        if (count < buffer.Length)
                        {
                            // If we filled only 2800 out of 4096 bits for example the rest will be zeros
                            // Which we don't want to take
                            var partialBuffer = new byte[count];
                            Array.Copy(buffer, partialBuffer, count);
                            data.AddRange(partialBuffer);
                            break;
                        }
                        else
                        {
                            data.AddRange(buffer);
                        }
                    }

                    // To convert from byte[] to string (text) we use Encoding
                    var requestAsString = Encoding.UTF8.GetString(data.ToArray());

                    var request = new HttpRequest(requestAsString);

                    Console.WriteLine($"{request.Method} {request.Path} {request.Headers.Count} headers");

                    HttpResponse response;
                    if (this.routeTable.ContainsKey(request.Path))
                    {
                        var action = this.routeTable[request.Path];
                        response = action(request);
                    }
                    else
                    {
                        // Not Found 404
                        response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
                    }

                    response.Headers.Add(new Header("Server", "SoftUni Server 1.0"));
                    response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
                        { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });
                    // 60 * 24 * 60 * 60 = 60 days
                    var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());
                    await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                    await stream.WriteAsync(response.Body, 0, response.Body.Length);
                }

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}