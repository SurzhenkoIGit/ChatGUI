using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Чат_GUI_
{
    public partial class Form1 : Form
    {
        private delegate void printer(string data);
        private delegate void cleaner();
        printer Printer;
        cleaner Cleaner;
        private Socket clientSock;
        private const string serverHost = "localhost";
        private const int port = 9933;
        private Thread _clientThread;
        public Form1()
        {
            InitializeComponent();
            Printer = new printer(Print);
            Cleaner = new cleaner(ClearChat);
            Connect();
            _clientThread = new Thread(listener);
            _clientThread.IsBackground = true;
            _clientThread.Start();
        }

        private void listener()
        {
            while (clientSock.Connected)
            {
                byte[] buf = new byte[8196];
                int bytesRec = clientSock.Receive(buf);
                string data = Encoding.UTF8.GetString(buf, 0, bytesRec);
                if (data.Contains("#updatechat"))
                {
                    UpdateChat(data);
                    continue;
                }
            }
        }
        private void Connect()
        {
            try
            {
                IPHostEntry iPHost = Dns.GetHostEntry(serverHost);
                IPAddress ip = iPHost.AddressList[0];
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                clientSock = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                clientSock.Connect(endPoint);
            }
            catch { Print("Сервер недоступен!"); }
        }
        private void ClearChat()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Cleaner);
                return;
            }
            txb_chat.Clear();
        }
        private void UpdateChat(string data)
        {
            ClearChat();
            string[] messages = data.Split('&')[1].Split('|');
            int countMsg = messages.Length;
            if (countMsg <= 0) { return; }
            for (int i = 0; i < countMsg; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) { continue; }
                    Print(String.Format("[{0}]:{1}.", messages[i].Split('~')[0], messages[i].Split('~')[1]));
                }
                catch { continue; }
            }
        }
        private void Send(string data)
        {
            try
            {
                byte[] buf = Encoding.UTF8.GetBytes(data);
                int bytesSend = clientSock.Send(buf);
            }
            catch { Print("Связь с сервером прервалась!"); }
        }
        private void Print(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg);
                return;
            }
            if (txb_chat.Text.Length == 0)
            {
                txb_chat.AppendText(msg);
            }
            else
            {
                txb_chat.AppendText(Environment.NewLine + msg);
            }
        }

        private void btn_EnterChat_Click(object sender, EventArgs e)
        {
            string Name = txb_userName.Text;
            if (string.IsNullOrEmpty(Name)) return;
            Send("#setname&" + Name);
            txb_chat.Enabled = true;
            txb_chat.BackColor = Color.White;
            txb_msg.Enabled = true;
            btn_send.Enabled = true;
            btn_EnterChat.Enabled = false;
            txb_userName.Enabled = false;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        private void SendMessage()
        {
            try
            {
                string data = txb_msg.Text;
                if (string.IsNullOrEmpty(data)) return;
                Send("#newmsg&" + data);
                txb_msg.Text = string.Empty;
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения"); }

        }

        private void txb_chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendMessage();
            }
        }

        private void txb_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendMessage();
            }
        }

    }
}
