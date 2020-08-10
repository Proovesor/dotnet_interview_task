using System;
using System.Net.Http;

namespace Interview_Task
{
    public interface IHttpResponseParser<out TResult>
    {
        TResult ParseResponse(HttpResponseMessage response);
    }
}
