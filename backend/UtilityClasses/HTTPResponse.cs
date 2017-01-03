using System.Net;

namespace backend.UtilityClasses
{
    class HTTPResponse
    {
        public HTTPResponse(string message, int code)
        {
            this.message = message;
            this.code = code;
        }

        public string message;
        public int code;

        public override string ToString()
        {
            return "HTTP Code " + code + ". " + message + ".";
        }

        public static void AddHTTPResponseToResponse(HTTPResponse httpResponse, ref HttpListenerResponse response)
        {
            if (httpResponse == null)
                httpResponse = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeInternalServerError();
            response.StatusCode = httpResponse.code;
            response.StatusDescription = httpResponse.message;
        }
    }
}
