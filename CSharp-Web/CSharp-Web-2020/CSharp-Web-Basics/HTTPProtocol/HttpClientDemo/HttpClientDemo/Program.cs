using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpClientDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n";
            //await ReadData();

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345); // Choose PORT
            tcpListener.Start(); // Open TCP Listener

            // daemon // service
            while (true)
            {
                var client = tcpListener.AcceptTcpClient(); // Get client
                using (var stream = client.GetStream()) // Get input from client
                {
                    byte[] buffer = new byte[1000000];
                    var length = stream.Read(buffer, 0, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer, 0, length); // Convert from byte[] to string
                    Console.WriteLine(requestString);

                    string html = $"<h1>Hello form IvanaServer! {DateTime.Now}</h1>" +
                        $"<form method=post><input name=username /><input name=password />" +
                        $"<input type=submit /></form>";

                    string response = "HTTP/1.1 307 Redirect" + NewLine +
                        "Server: IvanaServer 2023" + NewLine +
                        //"Location: https://www.google.com" + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        "Content-Length: " + html.Length + NewLine +
                        NewLine +
                        html + NewLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 70));
                }
            }
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/trainings/4105/asp-net-fundamentals-may-2023";
            HttpClient httpClient = new HttpClient();

            string html = await httpClient.GetStringAsync(url);
            Console.WriteLine(html);

            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine, 
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));
        }
    }
}