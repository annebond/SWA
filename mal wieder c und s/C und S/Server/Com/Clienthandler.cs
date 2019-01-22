using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Com
{

    public class Clienthandler
    {

        public Socket Socket { get; set; }
        public Action<string> Guiupdater { get; set; }

        public Clienthandler(Socket socket, Action<string> guiupdater)
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

        public void Senddata(string textsend)
        {
            Socket.Send(Encoding.UTF8.GetBytes(textsend));
        }
    }   
}
