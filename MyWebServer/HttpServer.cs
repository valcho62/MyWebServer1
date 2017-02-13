using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MyWebServer.Models;

namespace MyWebServer
{
    public class HttpServer
    {
        public TcpListener Listener { get; set; }
        public int Port { get; set; }
        public bool IsActive { get; set; }
        public HttpProcessor Processor { get; set; }

        public HttpServer(int port, IEnumerable<Route> routes )
        {
            Port = port;
            IsActive = true;
            Processor = new HttpProcessor(routes);
        }

        public void Listen()
        {
            this.Listener = new TcpListener(IPAddress.Any,this.Port);
            this.Listener.Start();

            while (IsActive)
            {
                var client =this.Listener.AcceptTcpClient();
                Thread thread = new Thread(() =>
                {
                    Processor.HandleClient(client);
                });
                thread.Start();
                Thread.Sleep(1);

            }
        }
    }
}