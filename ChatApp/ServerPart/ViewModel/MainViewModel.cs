using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ServerPart.Communication;

namespace ServerPart.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private Server server;
        private int port = 10100;
        private string ip = "127.0.0.1";
        private bool isConnected = false;

        public RelayCommand StartBtnClickCommand { get; set; }
        public RelayCommand StopBtnClickCommand { get; set; }
        public RelayCommand SaveBtnClickCommand { get; set; }
        public RelayCommand DropBtnClickCommand { get; set; }
        public ObservableCollection<string> Users { get; set; }
        public ObservableCollection<string> Messages { get; set; }
        public string SelectedUser{ get; set; }
        
        public int NoOfReceivedMessages
        {
            get { return Messages.Count; }
        }

        public MainViewModel()
        {

            Messages = new ObservableCollection<string>();
            Users = new ObservableCollection<string>();

            StartBtnClickCommand = new RelayCommand(
                () =>
                {
                    server = new Server(ip, port, UpdateGuiWithNewMessage);
                    server.StartAccepting();
                    isConnected = true;
                },
                () => { return !isConnected; });

            StopBtnClickCommand = new RelayCommand(
                () =>
                {
                    server.StopAccepting();
                    isConnected = false;
                },
               () => {return isConnected;});

            DropBtnClickCommand = new RelayCommand(() =>
                {
                    server.DisconnectSpecificClient(SelectedUser);
                    Users.Remove(SelectedUser);
                },
                () => { return (SelectedUser != null); });
        }

        private void UpdateGuiWithNewMessage(string message)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string name = message.Split(':')[0];
                    if (!Users.Contains(name))
                    {
                        //not in list => add it
                        Users.Add(name);
                    }

                    if (message.Contains("@quit"))
                    {
                        server.DisconnectSpecificClient(name);
                    }

                    //write message
                    Messages.Add(message);
                    //do this to inform the GUI about the update of the received message counter!
                    RaisePropertyChanged("NoOfReceivedMessages");
                });
        }
    }
}