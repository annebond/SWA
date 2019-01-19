using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;

namespace LegoCatalog.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<LegoItemVm> Items { get; set; }
        private LegoItemVm CurrentItem;

        public LegoItemVm currentItem
        {
            get { return CurrentItem; }
            set { CurrentItem = value; RaisePropertyChanged();}
        }


        public MainViewModel()
        {
            Items = new ObservableCollection<LegoItemVm>
            {
                new LegoItemVm("Digger", 300, "10+", new BitmapImage(new Uri("Images/bagger.jpg", UriKind.Relative))),
                new LegoItemVm("DeathStart", 500, "20+", new BitmapImage(new Uri("Images/todesstern.jpg", UriKind.Relative))),
                new LegoItemVm("Falcon", 2000, "15+", new BitmapImage(new Uri("Images/falcon.jpg", UriKind.Relative))),
                new LegoItemVm("TIE Figther", 600, "8+", new BitmapImage(new Uri("Images/tie-fighter.jpg", UriKind.Relative))),
                new LegoItemVm("Helicopter", 200, "5+", new BitmapImage(new Uri("Images/heli.jpg", UriKind.Relative)))
            };
        }
    }
}