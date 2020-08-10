using System;
using System.Net.Http;

namespace Interview_Task
{
    public class ResponseParser : IHttpResponseParser<string>
    {

        public string ParseResponse(HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
