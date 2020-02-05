namespace SIS.MvcFramework
{
    using System.IO;
    using System.Runtime.CompilerServices;

    using SIS.HTTP;
    using SIS.HTTP.Response;

    public abstract class Controller
    {
        protected HttpResponse View([CallerMemberName] string viewPath = null)
        {
            var layout = File.ReadAllText("Views/Shared/_Layout.html");
            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var html = File.ReadAllText("Views/" + controllerName + "/" + viewPath + ".html");
            var bodyWithLayout = layout.Replace("@RenderBody()", html);
            return new HtmlResponse(bodyWithLayout);
        }
    }
}
