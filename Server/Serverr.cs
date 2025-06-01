using System;
using System.Net.Sockets;
using System.Threading;
using Network.client;
using Network.server;
using Service;

namespace Server
{
    public class Serverr : ConcurrentServer
    {
        private readonly IAppService _Server;
        
        public Serverr(string host, int port, IAppService server) : base(host, port)
        {
            _Server = server;
            Console.WriteLine("Created server...");
        }
        protected override Thread CreateWorker(TcpClient client)
        {
            var Worker = new ClientObjectWorker(_Server, client);
            return new Thread(() => Worker.Run()); 
        }
    }
}