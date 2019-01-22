using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Com
{

    public class Client

    {
        TcpClient client;
        Socket s;
        private Action<string> informer;

        public Client(Action<string> informer)
        {
            this.informer = informer;
            client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Loopback, 1717));
            s = client.Client;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            int length;

            while (true)
            {
                byte[] buffer = new byte[512];
                length = s.Receive(buffer);
                string tmp = Encoding.UTF8.GetString(buffer, 0, length);
                informer(tmp);
            }
        }

        internal void Send(string sendtext)
        {
            s.Send(Encoding.UTF8.GetBytes(sendtext));
        }
    }   
}
