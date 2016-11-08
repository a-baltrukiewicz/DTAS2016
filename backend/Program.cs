namespace backend
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = backend.HTTPServer.ServerBuilder.CreateServer(8080);
            server.Start();
        }
    }
}
