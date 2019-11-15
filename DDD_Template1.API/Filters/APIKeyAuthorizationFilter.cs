using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DDD_Template1.API.Filters
{
    public class APIKeyAuthorizationFilterAttribute : AuthorizeAttribute
    {
        private string _message;

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            _message = string.Empty;

            IEnumerable<string> headers;

            var API_KEY = actionContext.Request.Headers.TryGetValues("API_KEY", out headers)
                ? headers.FirstOrDefault()
                : string.Empty;

            if (string.IsNullOrEmpty(API_KEY))
            {
                _message = "API_KEY não informada";

                return false;
            }

            return base.IsAuthorized(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!string.IsNullOrEmpty(_message))
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent(JsonConvert.SerializeObject(new { message = _message }), Encoding.UTF8, "application/json")
                };
            }
        }
    }
}