using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sample1.Communication
{
    class Server
    {
        private Socket socket;
        private List<Clienthandler> clients = new List<Clienthandler> ();

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Loopback, 9090));
            socket.Listen(10); //per definition hört ein server (network ebene)
            Task.Factory.StartNew(AcceptClients); //in einen Task auslagern, da es eine Endlosschleife ist. Sollte nicht in main laufen, da es sich irgendwann aufhängt
        }

        public void AcceptClients()
        {
            while (true)
            {
                clients.Add(new Clienthandler(socket.Accept()));
            }
        }
        public void SendToAllClients(byte[] data)
        {
            foreach (var item in clients)
            {
                item.SendData(data);
            }
        }

    }
}
