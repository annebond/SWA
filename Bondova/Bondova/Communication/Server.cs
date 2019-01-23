using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bondova.Communication
{
    class Server
    {
        // Sendtoallclients nicht gebraucht, da server nichts an clients schickt
        Socket s;
        public List<ClientHandler> listclient { get; set; }
        public Action<string> Guiupdater { get; set; }

        public Server(Action<string> guiupdater)
        {
            Guiupdater = guiupdater;
            listclient = new List<ClientHandler>();
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(new IPEndPoint(IPAddress.Loopback, 10106));
            s.Listen(5);
            Task.Factory.StartNew(Accepting);
        }

        private void Accepting()
        {
            while (true)
            {
                listclient.Add(new ClientHandler(s.Accept(), Guiupdater));
            }
        }
    }
}
