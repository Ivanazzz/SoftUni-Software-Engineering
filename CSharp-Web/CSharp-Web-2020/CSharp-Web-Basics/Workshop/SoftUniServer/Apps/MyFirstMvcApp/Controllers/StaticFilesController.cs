namespace MyFirstMvcApp.Controllers
{
    using SoftUniServer.HTTP;
    using SoftUniServer.MvcFramework;

    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);

            return response;
        }
    }
}
