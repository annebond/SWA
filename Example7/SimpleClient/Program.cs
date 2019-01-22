using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleClient
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            ClientCom com = new ClientCom();

            String[] demoData = new string[]
            {
                "Car{Engine;Tires;Center;Gear}",
                "Motorcylce{Engine;Tires;Center;Gear}",
                "Bicycler{Rack,Tires,Pedals}"
            };

            while (true)
            {
                com.Send(demoData[rand.Next(0,3)] + rand.Next(1,30) + ";" + DateTime.Now.AddMinutes(rand.Next(1,7)).ToString("hh:mm"));
                Thread.Sleep(3000);
            }
        }
    }
}
