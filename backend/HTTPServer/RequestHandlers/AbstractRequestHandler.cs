using System.Text.RegularExpressions;

namespace backend.HTTPServer.RequestHandlers
{
    /* Klasa abstrakcyjna służąca jako baza do wszystkich handlerów.
     */
    abstract class AbstractRequestHandler
    {
        //specialCase służy do wypadków szczególnych w deseń defaultowego
        public AbstractRequestHandler(string responsibilityURL, bool specialCase = false)
        {
            if (specialCase)
                _responsibilityURL = responsibilityURL;
            else
                _responsibilityURL = @"\/" + responsibilityURL;
        }
       

        abstract public string HandleRequest(System.Net.HttpListenerRequest request);

        public bool Match(string url)
        {
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
