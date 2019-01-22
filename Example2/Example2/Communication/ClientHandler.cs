using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Example2.Communication
{
    public class ClientHandler
    {
        byte[] buffer = new byte[512];
        private Action<string, Socket> action;
        private Thread clientReceiveThread;
        public Socket ClientSocket { get; set; }
        public string Username { get; set; }

        public ClientHandler(Socket socket, Action<string, Socket> action)
        {
            this.ClientSocket = socket;
            this.action = action;
            clientReceiveThread = new Thread(Receive);
            clientReceiveThread.Start();
        }

        private void Receive()
        {
            string message = "";

            while (clientReceiveThread.IsAlive)
            {
                int length = ClientSocket.Receive(buffer);
                message += Encoding.UTF8.GetString(buffer, 0, length);
                if (message.Contains("\r\n"))
                {
                    message = message.Substring(0, message.Length - 2);
                    action(message, ClientSocket);
                    message = "";
                }
            }
        }

        public void Send(string message)
        {
            //Only to inform the other Clients
            ClientSocket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
