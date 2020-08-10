using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Interview_Task
{
    public static class ApiService
    {
        public static HttpClient InitializeClient()
        {
            HttpClient ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            ApiClient.DefaultRequestHeaders
                            .Accept
                            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return ApiClient;
        }
    }
}
