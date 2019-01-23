using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bondova.Communication
{
    class ClientHandler
    {

        //kein send notwendig, da server nichts an client schickt
        public Socket Socket { get; set; }

        public Action<string> Guiupdater { get; set; }
        //   byte[] Buffer = new byte[512];

        public ClientHandler(Socket socket, Action<string> guiupdater)
        {
            Guiupdater = guiupdater;
            this.Socket = socket;
            Task.Factory.StartNew(Receiving);

        }

        private void Receiving()
        {
            while (true)
            {
                byte[] Buffer = new byte[512];
                int lenght = Socket.Receive(Buffer);
                string text = Encoding.UTF8.GetString(Buffer, 0, lenght);
                Guiupdater(text);
            }
        }
    }
}
