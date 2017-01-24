using backend.HTTPServer.RequestHandlers;
using Newtonsoft.Json;

namespace backend.HTTPServer
{
    /* Klasa służąca do tworzenia instancji HTTPServera. */
    class ServerBuilder
    {
        static JsonSerializerSettings CreateJSONSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            return settings;
        }

        public static HTTPServer CreateServer(uint port)
        {
            HTTPServer server = new HTTPServer(port, CreateJSONSettings());

            /* od najbardziej szczególnych do najbardziej ogólnych */
            server.AddRequestHandler(new TemplatePollsRequestHandler());
            server.AddRequestHandler(new PollsRequestHandler());
            server.AddRequestHandler(new UsersRequestHandler());
            server.AddRequestHandler(new LoginRequestHandler());
            server.AddRequestHandler(new TagsRequestHandler());
            server.AddRequestHandler(new DefaultRequestHandler()); //zawsze powinien być ostatni!

            return server;
        }
    }
}
