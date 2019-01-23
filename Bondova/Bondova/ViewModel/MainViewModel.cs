using System;
using System.Collections.ObjectModel;
using System.Windows;
using Bondova.Communication;
using Bondova.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Bondova.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private Communication.Server server;
        public ObservableCollection<ContainerTemp> Data { get; set; }
        private ContainerTemp currentSelected;
        public int Sum { get; set; }

        public ContainerTemp CurrentSelected
        {
            get { return currentSelected; }
            set { currentSelected = value;  RaisePropertyChanged();}
        }


        public MainViewModel()
        {
            Data = new ObservableCollection<ContainerTemp>();
            server = new Server(Guiadapter);
        }

        public void Guiadapter(string obj)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] temp = obj.Split(':', '{', '}', ';');
                    switch (temp[0])
                    {
                        case "F4711":
                            Data.Add(new Container2(temp[temp.Length - 1], temp[temp.Length - 2]));
                            break;
                        case "F5722":
                            Data.Add(new Container(temp[temp.Length - 1], temp[temp.Length - 2],
                                temp[temp.Length - 3]));
                            break;
                        case "F4701":
                            Data.Add(new Container3(temp[temp.Length - 1]));
                            break;
                    }

                    Sum = Data.Count;
                }
            );
        }
    }

}

