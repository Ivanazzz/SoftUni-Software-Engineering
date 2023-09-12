namespace SoftUniServer.HTTP
{
    public interface IHttpServer
    {
        void AddRoute(string path, Func<HttpRequest, HttpResponse> action);

        Task StartAsync(int port);
    }
}
