using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Com
{

    public class Server
    {
        Socket s, c;
        public List<Clienthandler> listclient { get; set; }
        public Action<string> Guiupdater { get; set; }

        public Server(Action<string> guiupdater)
        {
            Guiupdater = guiupdater;
            listclient = new List<Clienthandler>();
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(new IPEndPoint(IPAddress.Loopback, 1717));
            s.Listen(5);
            //c = s.Accept();
            Task.Factory.StartNew(Accepting);
        }

        private void Accepting()
        {
            while (true)
            {
                listclient.Add(new Clienthandler(s.Accept(), Guiupdater));
            }
        }

        public void Sendtoallclients(string textsend)
        {
            foreach(var item in listclient)
            {
                item.Senddata(textsend);
            }
        }
    }   
}
