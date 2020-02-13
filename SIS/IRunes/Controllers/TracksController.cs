namespace IRunes.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class TracksController : Controller
    {
        public HttpResponse Create()
        {
            return this.View();
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            return this.View();
        }
    }
}
