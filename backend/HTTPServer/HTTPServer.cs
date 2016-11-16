using System.Net;
using System.Collections.Generic;
using backend.HTTPServer.RequestHandlers;
using Newtonsoft.Json;

namespace backend.HTTPServer
{
    class HTTPServer
    {

        public HTTPServer(uint port, JsonSerializerSettings jsonSettings)
        {
            this.port = port;
            listener = new HttpListener();

            _requestHandlers = new List<AbstractRequestHandler>();

            var uri = "http://localhost:" + port.ToString() + "/";
            listener.Prefixes.Add(uri);
            this.jsonSettings = jsonSettings;
        }

        public void Start()
        {
            listener.Start();
            System.Console.WriteLine("Listening at " + port.ToString() + ". Ctrl+C to stop.");
            for (; ;) ManageRequests();
        }
        
        private void ManageRequests()
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            response.AddHeader("Access-Control-Allow-Origin", "*");

            string responseStr = MatchRequest(request);
            SendResponse(response, responseStr);
        }

        //metoda dopasowuje request do odpowiednego requestHandlera
        private string MatchRequest(HttpListenerRequest request)
        {
            foreach (var requestHandler in _requestHandlers)
            {
                if (requestHandler.Match(request.Url.ToString()))
                    return JsonConvert.SerializeObject(requestHandler.HandleRequest(request), jsonSettings);
            }
            return "<HTML>Unexpected error, run for you life!</HTML>";
        }

        private void SendResponse(HttpListenerResponse response, string responseString)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        public void AddRequestHandler(AbstractRequestHandler rh)
        {
            _requestHandlers.Add(rh);
        }

        List<AbstractRequestHandler> _requestHandlers;
        private HttpListener listener;
        private uint port;
        private JsonSerializerSettings jsonSettings;


    }

}
