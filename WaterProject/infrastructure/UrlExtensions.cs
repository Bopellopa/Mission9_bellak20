using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.infrastructure
{
    public static class UrlExtensions
    {
        //If it is not null or empty, the method returns the concatenation of the request path and query string.
        //Otherwise, it just returns the request path as a string.
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
