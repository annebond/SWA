using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sample1.Communication
{
    class Client
    {
        // client braucht socket, das ist das postfach vom server und dahin verbindet sich der client | mit der Action höre ich
        // Action brauche ich damit ich definiere was passiert wenn mal was daher kommt -> in MainViewModel gebe ich MsgReceived als Action mit
        Socket sock;
        private byte[] buffer = new byte[10];
        private Action<byte[]> informer; 

        public Client(Action<byte[]> informer)
        {
            this.informer = informer;
            TcpClient cl = new TcpClient();
            cl.Connect(new IPEndPoint(IPAddress.Loopback, 9090)); //client connected sich zum Server, Server ist am Rechner - IPAddress.Loopback = auf unserem Rechner
            sock = cl.Client; // ich hol mir den socket, damit ich sendern/empfangen kann -> methode Receive
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            int length;
            while (true)
            {
                length = sock.Receive(buffer);
                byte[] temp = new byte[length];
                Array.Copy(buffer,temp,length);
                informer(temp);
            }
        }
    }
}
