using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Interview_Task;

namespace Task_Test
{
    [TestClass]
    // Test poprawności działania metody Handle, należącej do klasy HttpRequestHandler.
    public class HttpRequestTests
    {
        [TestMethod]
        // Wykorzystano zewnętrzne API w celu sprawdzenia stosowalności DELETE http request method.
        public async Task TestDeleteMethod()
        {
            HttpClient ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            RequestHandler requestHandlerObject = new RequestHandler(ApiClient, new ResponseParser());
            string requestResult = await requestHandlerObject.HandleRequest(HttpMethod.Delete, postNumber: "1");

            Assert.AreEqual("{}", requestResult);
        }

        [TestMethod]
        // Wykorzystano nieprawidłowy adres url w celu wywołania wyjątku HttpRequestException
        public async Task TestUnknownHostException()
        {
            HttpClient ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://jsonplaceholder.typicode/");
            Exception expectedException = null;

            try
            {
                RequestHandler requestHandlerObject = new RequestHandler(ApiClient, new ResponseParser());
                string requestResult = await requestHandlerObject.HandleRequest(HttpMethod.Delete, postNumber: "1");
            }
            catch (HttpRequestException ex)
            {
                expectedException = ex;
            }

            Assert.AreEqual("No such host is known", expectedException.Message);
        }
    }
}