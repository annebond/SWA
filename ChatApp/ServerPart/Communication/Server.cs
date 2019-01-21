using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerPart.Communication
{
    class Server
    {
        private Socket serverSocket;
        private List<ClientHandler> clients = new List<ClientHandler>();
        private Action<string> GuiUpdater;
        private Thread acceptingThread;

        public Server(string ip, int port, Action<string> guiAdapter)
        {
            GuiUpdater = guiAdapter;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            serverSocket.Listen(5);
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
                    clients.Add(new ClientHandler(serverSocket.Accept(), new Action<string, Socket>(NewMessageReceived)));
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    //throw;
                }
            }
        }

        private void NewMessageReceived(string message, Socket senderSocket)
        {
            GuiUpdater(message);
            foreach (var item in clients)
            {
                if (item.Clientsocket != senderSocket)
                {
                    item.Send(message);
                }
            }
        }

        public void StopAccepting()
        {
            serverSocket.Close();
            acceptingThread.Abort(); 
            //close all client threads and connections
            foreach (var item in clients)
            {
                item.Close();
            }
            //remove all entries from the list
            clients.Clear();

        }

        public void DisconnectSpecificClient(string name)
        {
            foreach (var item in clients)
            {
                if (item.Name.Equals(name))
                {
                    item.Close();
                    clients.Remove(item); 
                    break;
                }
            }
        }
    }
}
