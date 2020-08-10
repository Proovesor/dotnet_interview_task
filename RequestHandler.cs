using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Interview_Task
{
    public class RequestHandler : HttpRequestHandler<object, string>, IRequestHandler
    {
        public string ResponseContent { get; set; }

        public RequestHandler(HttpClient httpClientProxy, IHttpResponseParser<string> parser) : base(httpClientProxy, parser)
        { }
        

        public async Task<string> HandleRequest(HttpMethod requestMethod, string postNumber = null,
            object payload = null, string url = "posts", IDictionary<string, string> headers = null)
        {
            if(!String.IsNullOrEmpty(postNumber))
            {
                url = $"{url}/{postNumber}";
            }
            else if(requestMethod == HttpMethod.Post || requestMethod == HttpMethod.Put || requestMethod == HttpMethod.Delete)
            {
                // Przykładowy header
                headers = new Dictionary<string, string>()
                {
                    { "Authorization", "Bearer __token__" }
                };
            }
            ResponseContent = await Handle(payload, requestMethod, url, headers, new CancellationToken());
            
            return ResponseContent;
        }

    }
}
