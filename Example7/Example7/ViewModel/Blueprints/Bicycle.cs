using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example7.ViewModel.Blueprints
{
    class Bicycle : ContructionDetails
    {
        public Bicycle(string time, int amount) : base(time, amount)
        {
            Parts = "Rack,Tires,Pedals";
        }
    }
}
