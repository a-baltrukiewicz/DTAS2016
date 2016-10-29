using System.Net;
using System.Collections.Generic;
using backend.HTTPServer.RequestHandlers;

namespace backend.HTTPServer
{
    class HTTPServer
    {

        public HTTPServer(uint port)
        {
            _port = port;
            _listener = new HttpListener();

            _requestHandlers = new List<AbstractRequestHandler>();

            var uri = "http://localhost:" + port.ToString() + "/";
            _listener.Prefixes.Add(uri);
        }

        public void Start()
        {
            _listener.Start();
            System.Console.WriteLine("Listening at " + _port.ToString() + ". Ctrl+C to stop.");
            for (; ;) ManageRequests();
        }
        
        private void ManageRequests()
        {
            HttpListenerContext context = _listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string responseStr = MatchRequest(request);
            SendResponse(response, responseStr);
        }

        //metoda dopasowuje request do odpowiednego requestHandlera
        private string MatchRequest(HttpListenerRequest request)
        {
            string response = "<HTML>Unexpected error, run for you life!</HTML>";
            foreach (var requestHandler in _requestHandlers)
            {
                if (requestHandler.Match(request.Url.ToString()))
                    return requestHandler.HandleRequest(request);
            }
            return response;
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
        private HttpListener _listener;
        private uint _port;


    }

}
