using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bondova.Model
{
    class Container2 : ContainerTemp
    {
        public Container2(string produkt1, string produkt2)
        {
            Produkt1 = "Tisch";
            Produkt2 = "Platte";
           
        }

        public string Produkt1 { get; set; }
        public string Produkt2 { get; set; }


        public string ContianerName { get; set; } = "F4711";


        
    }
}

