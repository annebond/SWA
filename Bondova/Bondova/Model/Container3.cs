using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bondova.Model
{
    class Container3 : ContainerTemp
    {
        public Container3(string produkt1)
        {
            Produkt1 = "Laptop";
        }

        public string Produkt1 { get; set; }


        public string ContianerName { get; set; } = "F5722";


    }
}

