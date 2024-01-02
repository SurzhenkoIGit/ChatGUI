using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ServerChat
{
    internal class Program
    {
        private const string serverHost = "localhost";
        private const int port = 9933;
        private static Thread _servThread;
        static void Main(string[] args)
        {
            _servThread = new Thread(StartServer);
            _servThread.IsBackground= true;
            _servThread.Start();
            while(true)
            {
                handleCommand(Console.ReadLine());
            }
        }
        private static void handleCommand(string cmd)
        {
            cmd = cmd.ToLower();
            if(cmd.Contains("/getusers"))
            {
                int countUsers = Server._clients.Count;
                for(int i = 0; i < countUsers; i++)
                {
                    Console.WriteLine("[{0}]: {1}", i, Server._clients[i].UserName);
                }
            }
        }
        private static void StartServer()
        {
            IPHostEntry iPHost = Dns.GetHostEntry(serverHost);
            IPAddress ip = iPHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            Socket servSock = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            servSock.Bind(endPoint);
            servSock.Listen(1000);
            Console.WriteLine("Server has been started with IP: {0}", endPoint);
            while(true)
            {
                try
                {
                    Socket clientSock = servSock.Accept();
                    Server.NewClient(clientSock);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }
    }
}
