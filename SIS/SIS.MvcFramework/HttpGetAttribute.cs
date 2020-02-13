namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute()
        {
        }

        public HttpGetAttribute(string url)
            : base(url)
        {
        }

        public override HttpMethodType Type => HttpMethodType.Get;
    }
}
