using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Specialized;

namespace ServerChat
{
    public class Client
    {
        private string _username;
        private Socket _handler;
        private Thread _th;

        public Client(Socket socket) 
        {
            _handler = socket;
            _th = new Thread(Listener);
            _th.IsBackground = true;
            _th.Start();
        }
        public string UserName
        {
            get { return _username; }
        }
        private void Listener()
        {
            while(true)
            {
                try
                {
                    byte[] buf = new byte[1024];
                    int bytesRec = _handler.Receive(buf);
                    string data = Encoding.UTF8.GetString(buf, 0, bytesRec);
                    HandleCommand(data);
                }
                catch 
                {
                    Server.EndClient(this);
                    return;
                }
            }
        }
        public void End()
        {
            try
            {
                _handler.Close();
                try
                {
                    _th.Abort();
                }
                catch { }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
        private void HandleCommand(string command)
        {
            if(command.Contains("#setname"))
            {
                _username= command.Split('&')[1];
                UpdateChat();
                return;
            }
            if(command.Contains("#newmsg"))
            {
                string message = command.Split('&')[1];
                ChatController.AddMessage(_username, message);
                return;
            }
        }
        public void UpdateChat()
        {
            SendChat(ChatController.GetChat());
        }
        public void SendChat(string command)
        {
            try
            {
                
                int bytesSend = _handler.Send(Encoding.UTF8.GetBytes(command));
                if(bytesSend > 0)
                {
                    Console.WriteLine("Success!");
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine("Error with send command: {0}", e.Message); Server.EndClient(this) ;
            }
        }
    }
}
