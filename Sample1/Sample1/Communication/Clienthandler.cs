using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sample1.Communication
{
    internal class Clienthandler //internal nicht relevant - es geht nur darum wer die klasse verwenden kann
    {
        private Socket socket;

        public Clienthandler(Socket accept)
        {
            this.socket = accept;
        }

        public void SendData(byte[] data)
        {
            socket.Send(data);
        }
    }
}
