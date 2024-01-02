using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerChat
{
    public static class ChatController
    {
        private const int MaxMesCount = 100;
        public static List<message> Chat = new List<message>();
        public struct message
        {
            public string _userName;
            public string _message;
            public message(string userName, string message)
            {
                _userName = userName; 
                _message = message;
            }
        }
        public static void AddMessage(string userName, string msg)
        {
            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(msg))
                {
                    return;
                }
                int chatCount = Chat.Count;
                if (chatCount > MaxMesCount)
                {
                    ClearChat();
                }
                message NewMsg = new message(userName, msg);
                Chat.Add(NewMsg);
                Console.WriteLine("New message from {0}", userName);
                Server.UpdateAllChats();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error with add message: {0}", e.Message);
            }
        }
        public static void ClearChat()
        {
            Chat.Clear();
        }
        public static string GetChat()
        {
            try
            {
                string data = "#updatechat&";
                int countMsg = Chat.Count;
                if(countMsg <= 0)
                {
                    return string.Empty;
                }
                for(int i = 0; i < countMsg; i++)
                {
                    data += String.Format("{0}~{1}|", Chat[i]._userName, Chat[i]._message);
                }
                return data;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error with getchat: {0}", e.Message);
                return string.Empty;
            }
        }
    }
}
