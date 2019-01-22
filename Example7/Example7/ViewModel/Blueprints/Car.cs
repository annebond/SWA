using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example7.ViewModel.Blueprints
{
    class Car : ContructionDetails
    {
        public Car(string completionTime, int amount) : base(completionTime, amount)
        {
            Parts = "Engine,Tires,Center,Gear";
        }
    }
}
