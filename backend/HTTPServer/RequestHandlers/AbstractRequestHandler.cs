using backend.UtilityClasses;
using System.Net;
using System.Text.RegularExpressions;

namespace backend.HTTPServer.RequestHandlers
{
    /* Klasa abstrakcyjna służąca jako baza do wszystkich handlerów.
     */
    abstract class AbstractRequestHandler
    {
        //specialCase służy do wypadków szczególnych w deseń defaultowego request handlera
        public AbstractRequestHandler(string responsibilityURL, bool specialCase = false)
        {
            if (specialCase)
                _responsibilityURL = responsibilityURL;
            else
                _responsibilityURL = @"\/" + responsibilityURL;
        }
       
        //powinien zwracać obiekt, który zostanie sparsowany do JSONa
        public object HandleRequest(HttpListenerRequest request, ref HTTPResponse response)
        {
            try
            {
                if (request.HttpMethod == "GET")
                    return HandleGET(request, ref response);
                else if (request.HttpMethod == "POST")
                    return HandlePOST(request, ref response);
                else if (request.HttpMethod == "PUT")
                    return HandlePUT(request, ref response);
                else if (request.HttpMethod == "DELETE")
                    return HandleDELETE(request, ref response);
            }
            catch (System.Exception ex)
            {
                string error = "Error: " + ex.TargetSite.ToString() + " at " + ex.Source.ToString() + ". ";
                error += "URL: " + request.Url;
                error += ". Please inform site administrator.";
                return error;
            }
            string baseResponse = "Invalid method";
            return baseResponse;
        }

        public static string GetRequestData(HttpListenerRequest request)
        {
            if (!request.HasEntityBody)
            {
                System.Console.WriteLine("No client data was sent with the request.");
                return ("");
            }
            System.IO.Stream body = request.InputStream;
            System.Text.Encoding encoding = request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            string read = reader.ReadToEnd();
            body.Close();
            reader.Close();
            return read;
            // If you are finished with the request, it should be closed also.
        }



        protected RESTCollectionElementID GetCollectionElementID(HttpListenerRequest request)
        {
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(request.RawUrl);
            if (match.Success)
                return new RESTCollectionElementID((uint)System.Int32.Parse(match.Value));
            else
                return new RESTCollectionElementID();
        }


        abstract public object HandleGET(HttpListenerRequest request, ref HTTPResponse response);
        abstract public object HandlePOST(HttpListenerRequest request, ref HTTPResponse response);
        abstract public object HandlePUT(HttpListenerRequest request, ref HTTPResponse response);
        abstract public object HandleDELETE(HttpListenerRequest request, ref HTTPResponse response);
        public bool Match(string url)
        {
            //Regex łapiący URLe
            Regex rx = new Regex(@"^http[s]{0,1}:\/\/[a-zA-Z]*:\d+" + _responsibilityURL + @"(\/.*$|$)"
                                , RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(url);
        }

        //za parsowanie jakich URLów odpowiedzialny jest handler
        //Dla "example oznacza to, że handler odpowiada za requesty w deseń http://localhost:8080/example, http://localhost:8080/example/5,
        //http://localhost:8080/example/5/example2 itd.
        string _responsibilityURL;
    }
}
