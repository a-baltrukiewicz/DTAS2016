using backend.HTTPServer.RequestHandlers;

namespace backend.HTTPServer
{
    /* Klasa służąca do tworzenia instancji HTTPServera. */
    class ServerBuilder
    {
        public static HTTPServer CreateServer(uint port)
        {
            HTTPServer server = new HTTPServer(port);

            server.AddRequestHandler(new PollsRequestHandler());

            server.AddRequestHandler(new DefaultRequestHandler()); //zawsze powinien być ostatni!

            return server;
        }
    }
}
