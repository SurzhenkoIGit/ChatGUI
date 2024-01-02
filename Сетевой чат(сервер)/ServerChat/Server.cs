using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerChat
{
    public class Server
    {
        public static List<Client> _clients = new List<Client>();

        public static void NewClient(Socket socket)
        {
            try
            {
                Client client = new Client(socket);
                _clients.Add(client);
                Console.WriteLine("User {0} has been connected!", socket.RemoteEndPoint);

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void EndClient(Client client)
        {
            try
            {
                client.End();
                _clients.Remove(client);
                Console.WriteLine("User {0} has been disconnected!", client.UserName);
            } 
            catch(Exception ex) 
            {
                Console.WriteLine("Error with disconnect of client: {0}", ex.Message);
            }
        }
        public static void UpdateAllChats()
        {
            try
            {
                int countUser = _clients.Count;
                for(int i = 0; i < countUser; i++)
                {
                    _clients[i].UpdateChat();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error with updateAlLChats: {0}.", ex.Message);
            }
        }
    }
}
