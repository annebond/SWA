using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientPart.Communication
{
    class Client
    {

        Socket clientsocket;
        byte[] buffer = new byte[512];
        Action<string> informer;
        Action AbortInformer;

        public Client(string ip, int port, Action<string> informer, Action abortInformer)
        {
            try
            {
                this.informer = informer;
                this.AbortInformer = abortInformer;
                TcpClient cl = new TcpClient();
                cl.Connect(IPAddress.Parse(ip), port);
                clientsocket = cl.Client;
                Task.Factory.StartNew(Receive);
            }
            catch (Exception e)
            {
                informer("Server not ready");
                AbortInformer();
            }
        }

        private void Receive()
        {
            string temp="";
            while (!temp.Contains("@quit"))
            {
                var length = clientsocket.Receive(buffer);
                temp = Encoding.UTF8.GetString(buffer, 0, length);
                informer(temp);
            }
            Close();
        }

        public void Send(string message)
        {
            if (clientsocket != null) //check if clientsocket connected!
            {
                clientsocket.Send(Encoding.UTF8.GetBytes(message));
            }
        }

        public void Close()
        {
            clientsocket.Close();
            AbortInformer();
        }
    }
}
