using backend.UtilityClasses;
namespace backend.ObjectsFactories
{
    class HTTPResponseFactory
    {
        private HTTPResponseFactory() { }
        static private HTTPResponseFactory instance;

        public static HTTPResponseFactory GetObject()
        {
            if (instance == null)
                instance = new HTTPResponseFactory();
            return instance;
        }

        //1XX
        public HTTPResponse CreateCodeContinue()
        {
            return new HTTPResponse("Continue", 100);
        }

        //2XX
        public HTTPResponse CreateCodeOK()
        {
            return new HTTPResponse("OK", 200);
        }
        public HTTPResponse CreateCodeCreated()
        {
            return new HTTPResponse("Created", 201);
        }
        public HTTPResponse CreateCodeNoContent()
        {
            return new HTTPResponse("No content", 204);
        }
        //4XX
        public HTTPResponse CreateCodeBadRequest()
        {
            return new HTTPResponse("Bad Request", 400);
        }
        public HTTPResponse CreateCodeUnauthorized()
        {
            return new HTTPResponse("Unauthorized", 401);
        }
        public HTTPResponse CreateCodeNotFound()
        {
            return new HTTPResponse("Not Found", 404);
        }

        //5XX
        public HTTPResponse CreateCodeInternalServerError()
        {
            return new HTTPResponse("Internal Server Error", 500);
        }
        public HTTPResponse CreateCodeNotImplemented()
        {
            return new HTTPResponse("Not Implemented", 501);
        }


    }
}
