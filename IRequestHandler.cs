using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Interview_Task
{
    public interface IRequestHandler
    {
        Task<string> HandleRequest(HttpMethod requestMethod, string postNumber, object payload, string url, IDictionary<string, string> headers);
    }
}
