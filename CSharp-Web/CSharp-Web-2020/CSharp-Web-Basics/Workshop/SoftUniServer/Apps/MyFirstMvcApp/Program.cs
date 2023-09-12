namespace MyFirstMvcApp
{
    using System.Text;

    using SoftUniServer.HTTP;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            // The code below is called "route table"
            server.AddRoute("/", HomePage);
            server.AddRoute("/favicon.ico", Favicon);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);
            // End of route table

            await server.StartAsync(80);
        }

        static HttpResponse HomePage(HttpRequest request)
        {
            var responseHtml = "<h1>Welcome!</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        static HttpResponse Favicon(HttpRequest request)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);

            return response;
        }

        static HttpResponse About(HttpRequest request)
        {
            var responseHtml = "<h1>About...</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        static HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>Login...</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}