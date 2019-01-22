using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Example2.Communication
{
    public class Server
    {
        Socket servSocket;
        List<ClientHandler> clients = new List<ClientHandler>();
        Action<string, string> messageInformer;
        Action<string> userInformer;
        Thread acceptingThread;

        public Server(Action<string, string> msginformer, Action<string> userInfo)
        {
            userInformer = userInfo;
            messageInformer = msginformer;
            servSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            servSocket.Bind(new IPEndPoint(IPAddress.Loopback, 8055));
            servSocket.Listen(5);
        }

        public void StartAccepting()
        {
            acceptingThread = new Thread(new ThreadStart(Accept));
            acceptingThread.IsBackground = true;
            acceptingThread.Start();
        }

        private void Accept()
        {
            while (acceptingThread.IsAlive)
            {
                try
                {
                    clients.Add(new ClientHandler(servSocket.Accept(), new Action<string, Socket>(NewMessageReceive)));
                }
                catch (Exception e)
                {
                    //execute if socket.close is called
                }
            }
        }

        private void NewMessageReceive(string message, Socket senderSocket)
        {
            //messageInformer(message);
            foreach (var item in clients)
            {
                if (item.ClientSocket != senderSocket)
                {
                    item.Send(message);
                }

                if (item.ClientSocket == senderSocket)
                {
                    if (item.Username == null)
                    {
                        item.Username = message;
                        userInformer(item.Username);
                    }
                    else
                    {
                        messageInformer(item.Username, message);
                    }
                }
            }
        }
    }
}