using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Interview_Task
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            HttpClient _ClientProxy = ApiService.InitializeClient();
            await RunProgram(_ClientProxy);
        }

        public static async Task RunProgram(HttpClient _ClientProxy)
        {
            string responseContent = null;
            int userChoice;

            Console.Write("Hello! Choose which request you would like to send! \n" +
                "1. Get posts.\n" +
                "2. Add post.\n" +
                "3. Update post.\n" +
                "4. Delete post.\n");

            userChoice = Convert.ToInt32(Console.ReadLine());
            switch(userChoice)
            {
                case 1:
                    responseContent = await DisplayGetMenu(_ClientProxy);
                    break;
                case 2:
                    responseContent = await DisplayPostUpdateMenu(_ClientProxy, "POST");
                    break;
                case 3:
                    string postToUpdate;

                    Console.Clear();
                    Console.WriteLine("Choose which post to update (number).");
                    postToUpdate = Console.ReadLine();

                    responseContent = await DisplayPostUpdateMenu(_ClientProxy, "PUT", postToUpdate);
                    break;
                case 4:
                    await DisplayDeleteMenu(_ClientProxy);
                    responseContent += "\n\nPost successfully deleted";
                    break;
                default:
                    Console.WriteLine("You typed in wrong input.");
                    break;
            }
            Console.Clear();
            Console.WriteLine(responseContent);
            Console.Write("\n\n");
            Console.WriteLine("Click to return to the main page.");
            Console.ReadKey();
            Console.Clear();
            await RunProgram(_ClientProxy);
        }

        static public async Task<string> DisplayGetMenu(HttpClient _ClientProxy)
        {
            RequestHandler getRequestHandler;
            int getRequestUserChoice;
            string response = null;

            Console.Clear();
            Console.Write("1. All records.\n" +
                "2. Particular record.\n");
            getRequestUserChoice = Convert.ToInt32(Console.ReadLine());

            switch (getRequestUserChoice)
            {
                case 1:
                    Console.Clear();
                    getRequestHandler = new RequestHandler(_ClientProxy, new ResponseParser());
                    response = await getRequestHandler.HandleRequest(HttpMethod.Get);
                    break;
                case 2:
                    string postToDisplay;

                    Console.Clear();
                    Console.WriteLine("Choose particular record (number).");
                    postToDisplay = Console.ReadLine();

                    getRequestHandler = new RequestHandler(_ClientProxy, new ResponseParser());
                    response = await getRequestHandler.HandleRequest(HttpMethod.Get, postNumber: postToDisplay);
                    break;
                default:
                    Console.WriteLine("You typed in wrong input.");
                    break;
            }
            return response;
        }

        static public async Task<string> DisplayPostUpdateMenu(HttpClient _ClientProxy, string methodType, string postToUpdate = "")
        {
            string response = null, body, title;
            int postId, userId;

            Console.Clear();
            Console.Write("Provide all specific data:\n" +
                "1) ID of new post:  ");
            postId = Convert.ToInt32(Console.ReadLine());
            Console.Write("2) Your ID:  ");
            userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("3) Content of your post:  ");
            body = Console.ReadLine();
            Console.Write("4) Title of the post:  ");
            title = Console.ReadLine();
            Console.Clear();

            Post createdPost = new Post(postId, userId, title, body);
            var postToJson = new JavaScriptSerializer().Serialize(createdPost);
            var stringContent = new StringContent(postToJson, Encoding.UTF8, "application/json");
            RequestHandler requestHandler = new RequestHandler(_ClientProxy, new ResponseParser());

            if (methodType == "POST")
            {
                response = await requestHandler.HandleRequest(HttpMethod.Post, payload: stringContent);
            }
            else if(methodType == "PUT")
            {
                response = await requestHandler.HandleRequest(HttpMethod.Put, payload: stringContent, postNumber: postToUpdate);
            }

            return response;
        }

        static public async Task DisplayDeleteMenu(HttpClient _ClientProxy)
        {
            string postToDelete;

            Console.Clear();
            Console.WriteLine("Choose which post to delete (number).");
            postToDelete = Console.ReadLine();
            Console.Clear();

            RequestHandler requestHandler = new RequestHandler(_ClientProxy, new ResponseParser());
            await requestHandler.HandleRequest(HttpMethod.Delete, postNumber: postToDelete);
        }
    }

}

