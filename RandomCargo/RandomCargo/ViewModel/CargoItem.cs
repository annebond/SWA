using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCargo.ViewModel
{
    public class CargoItem : ViewModelBase
    {

        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private int itemAmount;

        public int ItemAmount
        {
            get { return itemAmount; }
            set { itemAmount = value; }
        }

        private float itemWeight;

        public float ItemWeight
        {
            get { return itemWeight; }
            set { itemWeight = value; }
        }

        public CargoItem(string itemName, int itemAmount, float itemWeight)
        {
            ItemName = itemName;
            ItemAmount = itemAmount;
            ItemWeight = itemWeight;
        }

    }
}
