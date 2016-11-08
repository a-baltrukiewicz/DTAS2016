namespace backend
{
    class Program
    {
        static void Main(string[] args)
        {
            var SQLCommunicator = new backend.HTTPServer.SQLCommunication();
            SQLCommunicator.connectToSQLServer();
            SQLCommunicator.executeSQLCommand("SELECT * FROM USERS");
            SQLCommunicator.disconnectFromSQLServer();
            var server = backend.HTTPServer.ServerBuilder.CreateServer(8080);
            server.Start();
        }
    }
}
