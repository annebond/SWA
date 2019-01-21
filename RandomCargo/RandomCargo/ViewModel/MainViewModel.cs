using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Windows;
using GalaSoft.MvvmLight;
using System;
using System.Threading;

namespace RandomCargo.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Cargo> WaitingFor { get; set; }
        public ObservableCollection<Cargo> Ready { get; set; }
        public ObservableCollection<Cargo> Details { get; set; }
        public ObservableCollection<CargoItem> cargoitems { get; set; }
        public Cargo[] cargos;

        public MainViewModel()
        {
            cargoitems = new ObservableCollection<CargoItem>();
            WaitingFor = new ObservableCollection<Cargo>();
            Ready = new ObservableCollection<Cargo>();
            Details = new ObservableCollection<Cargo>();
            

            cargoitems.Add(new CargoItem("Window", 20, 30));
            cargoitems.Add(new CargoItem("Brick", 30, 50));
            cargoitems.Add(new CargoItem("Timber", 50, 180));

            cargos = new Cargo[4];
            cargos[0] = new Cargo("Vienna", numberGenerator(1, 5), cargoitems);
            cargos[1] = new Cargo("Berlin", numberGenerator(2, 5), cargoitems);
            cargos[2] = new Cargo("Boston", numberGenerator(1, 5), cargoitems);
            cargos[3] = new Cargo("London", numberGenerator(3, 5), cargoitems);




            Thread objMyThread = new Thread(mymethod);
            objMyThread.Start();
            Thread objMyThread2 = new Thread(addToReady);
            objMyThread2.Start();

        }

        private void addToReady()
        {
            System.Threading.Thread.Sleep(5000);
            foreach (Cargo i in WaitingFor)
            {
                int temp = (i.DeliveryTime * 1000);
                System.Threading.Thread.Sleep(temp);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    Ready.Add(i);
                });
            }
        }

        private void mymethod()
        {
            foreach (Cargo i in cargos)
            {
                System.Threading.Thread.Sleep(5000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    WaitingFor.Add(i);
                });
            }
            /*
            System.Threading.Thread.Sleep(5000);
            App.Current.Dispatcher.Invoke((Action)delegate
            {
               WaitingFor.Add(cargos[numberGenerator(0, 4)]);
            });
            */
        }

        private static int numberGenerator(int a, int b)
        {
            Random rnd = new Random();
            return rnd.Next(a, b);
        }

}
}