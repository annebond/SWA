using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCom
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            Client com = new Client();
            String[] demoData = new string[]
            {
                "F4711:{Banane,Autoreifen,Switch};{Obst,PS4Pro,Box}",
                "F5722:{PC}{Banane,Autoreifen,Switch};{Obst,PS4Pro,Box}",
                "F4701:{Autoreifen,Switch}"
            };

            while (true)
            {
                com.Send(demoData[rand.Next(0,3)]);
            }
        }
    }

}