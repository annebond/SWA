﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClient
{
    class ClientCom
    {
        //schickt nur - kein Receive(), keine Action
        TcpClient client;
        Socket s;

        public ClientCom()
        {
            client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Loopback, 9090));
            s = client.Client;

        }



        internal void Send(string sendtext)
        {
            s.Send(Encoding.UTF8.GetBytes(sendtext));
        }
    }
}
