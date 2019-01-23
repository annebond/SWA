using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bondova.Model
{
    class Container : ContainerTemp
    {   
        public Container(string produkt1, string produkt2, string produkt3)
        {
            Produkt1 = "Banane";
            Produkt2 = "Apfel";
            Produkt3 = "Snickers";
        }

        public string Produkt1 { get; set; }
        public string Produkt2 { get; set; }
        public string Produkt3 { get; set; }

        public string ContianerName { get; set; } = "F4701";

    }
}

