using DDD_Template1.API.Filters;
using System.Web.Http.Filters;

namespace DDD_Template1.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            //filters.Add(new APIKeyAuthorizationFilterAttribute());
        }
    }
}