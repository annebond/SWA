using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace RandomCargo.ViewModel
{
    public class Cargo : ViewModelBase
    {
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; RaisePropertyChanged(); }
        }

        private int deliveryTime;

        public int DeliveryTime
        {
            get { return deliveryTime; }
            set { deliveryTime = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<CargoItem> cargos { get; set; }

        public Cargo(string description, int deliveryTime, ObservableCollection<CargoItem> cargos)
        {
            Description = description;
            DeliveryTime = deliveryTime;
            this.cargos = cargos;
        }
    }
}
