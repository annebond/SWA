using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerPart.Communication
{
    class ClientHandler
    {
        public Socket Clientsocket { get; set; }
        private Action<string, Socket> action;
        private byte[] buffer = new byte[512];
        private Thread clientReceiveThread;
        public string endMessage = "@quit";
        public string Name { get; set; }

        public ClientHandler(Socket socket, Action<string, Socket> action)
        {
            this.Clientsocket = socket;
            this.action = action;
            //start receiving in a new thread
            clientReceiveThread = new Thread(Receive);
            clientReceiveThread.Start();
        }

        private void Receive()
        {
            string message = "";
            while (!message.Contains(endMessage))
            {
                int length = Clientsocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                if (Name == null && message.Contains(":"))
                {
                    Name = message.Split(':')[0];
                }

                action(message, Clientsocket);
            }
            Close();
        }
        
        public void Close()
        {
            // send endmessage to client, disconnect, abort client threat
            Send(endMessage);
            Clientsocket.Close(1);
            clientReceiveThread.Abort();
        }

        public void Send(string message)
        {
            Clientsocket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
