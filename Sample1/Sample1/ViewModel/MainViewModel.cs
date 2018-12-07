using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Sample1.Communication;
using System;

namespace Sample1.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {

        private bool toggle1;
        private bool toggle2;
        private bool toggle3;
        private bool toggle4;

        public bool Toggle1
        {
            get { return toggle1; }
            set { toggle1 = value; RaisePropertyChanged(); }
        }

        public bool Toggle2
        {
            get { return toggle2; }
            set { toggle2 = value; RaisePropertyChanged(); }
        }
        public bool Toggle3
        {
            get { return toggle3; }
            set { toggle3 = value; RaisePropertyChanged(); }
        }

        public bool Toggle4
        {
            get { return toggle4; }
            set { toggle4 = value; RaisePropertyChanged(); }
        }

        private Client client;
        private Server server;

        public bool isConnected { get; set; }

        public RelayCommand ClientBtnCommand { get; set; }
        public RelayCommand ServerBtnCommand { get; set; }

        public ObservableCollection<string> History { get; set; }

        public RelayCommand<int> ToggleBtnClickedCmd { get; set; }

        private bool actAsServer;

        public bool ActAsServer
        {
            get { return actAsServer; }
            set { actAsServer = value; RaisePropertyChanged();}
        }



        public MainViewModel()
        {
            History = new ObservableCollection<string>();
            ServerBtnCommand = new RelayCommand(() =>
            {   // hier steht was passiert wenn Relay Command passiert
                ActAsServer = true;
                server = new Server();
                isConnected = true;
            },
                () =>
                {//was gibt Relay Command zurück
                    return !isConnected;
                });

            ClientBtnCommand = new RelayCommand(() =>
                {   // hier steht was passiert wenn Relay Command passiert
                    ActAsServer = false;
                    client = new Client(MsgReceived);
                    isConnected = true;
                },
                () =>
                {//was gibt Relay Command zurück
                    return !isConnected;

                });

            ToggleBtnClickedCmd = new RelayCommand<int>(
                (p) =>
                {
                    switch (p)
                    {
                        case 1: Toggle1 = !Toggle1;
                            break;
                        case 2:
                            Toggle2 = !Toggle2;
                            break;
                        case 3:
                            Toggle3 = !Toggle3;
                            break;
                        case 4:
                            Toggle4 = !Toggle4;
                            break;
                        default:
                            break;
                    }

                    if (ActAsServer)
                    {
                        server.SendToAllClients(new byte[]
                        {
                            Convert.ToByte(Toggle1),
                            Convert.ToByte(Toggle2),
                            Convert.ToByte(Toggle3),
                            Convert.ToByte(Toggle4)
                        });
                        History.Add("Toggle1: " + Toggle1 + "...");
                        History.Add("Toggle2: " + Toggle2 + "...");
                        History.Add("Toggle3: " + Toggle3 + "...");
                        History.Add("Toggle4: " + Toggle4 + "...");
                    }
                });

        }

        private void MsgReceived(byte[] obj)
        {
            App.Current.Dispatcher.Invoke(() => //current dispather holt den aktuellen threat, der auf die aktuelle GUI zugreifen kann
            {
                Toggle1 = Convert.ToBoolean(obj[0]);
                Toggle2 = Convert.ToBoolean(obj[1]);
                Toggle3 = Convert.ToBoolean(obj[2]);
                Toggle4 = Convert.ToBoolean(obj[3]);
                History.Add("Toggle1: " + Toggle1 + "...");
                History.Add("Toggle2: " + Toggle2 + "...");
                History.Add("Toggle3: " + Toggle3 + "...");
                History.Add("Toggle4: " + Toggle4 + "...");
            });
            
        }
    }
}