using backend.UtilityClasses;
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
        public object HandleRequest(System.Net.HttpListenerRequest request)
        {
            this.request = request;
            if (request.HttpMethod == "GET")
                return HandleGET(request);
            else if (request.HttpMethod == "POST")
                return HandlePOST(request);
            else if (request.HttpMethod == "PUT")
                return HandlePUT(request);
            else if (request.HttpMethod == "DELETE")
                return HandleDELETE(request);
            string baseResponse = "Invalid method";
            return baseResponse;
        }
        protected RESTCollectionElementID GetCollectionElementID(System.Net.HttpListenerRequest request)
        {
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(request.RawUrl);
            if (match.Success)
                return new RESTCollectionElementID((uint)System.Int32.Parse(match.Value));
            else
                return new RESTCollectionElementID();
        }


        abstract public object HandleGET(System.Net.HttpListenerRequest request);
        abstract public object HandlePOST(System.Net.HttpListenerRequest request);
        abstract public object HandlePUT(System.Net.HttpListenerRequest request);
        abstract public object HandleDELETE(System.Net.HttpListenerRequest request);
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
        protected System.Net.HttpListenerRequest request;
    }
}
