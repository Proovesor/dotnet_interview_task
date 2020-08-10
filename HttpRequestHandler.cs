using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Interview_Task
{
    public abstract class HttpRequestHandler<TRequest, TResponse>
    {
        internal HttpClient _httpClientProxy;
        public IHttpResponseParser<TResponse> _parser { get; set; }

        public HttpRequestHandler(HttpClient httpClientProxy, IHttpResponseParser<TResponse> parser)
        {
            _httpClientProxy = httpClientProxy;
            _parser = parser;
        }

        public async Task<TResponse> Handle(object payload, HttpMethod methodName, string url,
            IDictionary<string, string> additionalHeaders, CancellationToken cancellationToken)
        {
            string uriString = $"{_httpClientProxy.BaseAddress}{url}";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(methodName, new Uri(uriString));

            if (payload != null)
            {
                httpRequestMessage.Content = payload as HttpContent;
            }

            if (additionalHeaders != null)
            {
                foreach (KeyValuePair<string, string> header in additionalHeaders)
                {
                    httpRequestMessage.Headers.Add(header.Key, header.Value);
                }
            }

            try
            {
                HttpResponseMessage response = await _httpClientProxy.SendAsync(httpRequestMessage, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    throw new EndOfStreamException(String.Join(",", response.Headers));
                }
                return _parser.ParseResponse(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Could not find such host or there is problem with internet connection.");
                throw new HttpRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occurred. \n" +
                    "Log: {0}", ex.Message);
                throw new Exception(ex.Message);

            }
        }  
    } 
}