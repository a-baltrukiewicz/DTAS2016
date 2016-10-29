using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
