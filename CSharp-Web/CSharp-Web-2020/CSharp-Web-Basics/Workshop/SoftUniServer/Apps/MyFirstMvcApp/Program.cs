namespace MyFirstMvcApp
{
    using MyFirstMvcApp.Controllers;
    using SoftUniServer.HTTP;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            // The code below is called "route table"
            server.AddRoute("/", new HomeController().Index);
            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);
            server.AddRoute("/about", new HomeController().About);
            server.AddRoute("/users/login", new UsersController().Login);
            server.AddRoute("/users/register", new UsersController().Register);
            // End of route table

            await server.StartAsync(80);
        }
    }
}