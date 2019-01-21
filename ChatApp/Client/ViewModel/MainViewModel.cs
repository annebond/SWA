using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ClientPart.Communication;
using System.Windows.Input;

namespace ClientPart.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public bool isConnected = false;
        private Client clientcom;

        public string ChatName { get; set; }
        public string Message { get; set; }
        public ObservableCollection<string> ReceivedMessages { get; set; }
        public RelayCommand ConnectBtnClickCmdCommand { get; set; }
        public RelayCommand SendBtnClickCmdCommand { get; set; }

        public MainViewModel()
        {
            Message = "";
            ReceivedMessages = new ObservableCollection<string>();
            ConnectBtnClickCmdCommand = new RelayCommand(
                () =>
                {
                    isConnected = true;
                    clientcom = new Client("127.0.0.1", 10100, new Action<string>(NewMessageReceived), ClientDissconnected);
                    
                },
                () =>
                {
                    return (!isConnected);
                }
                );
            SendBtnClickCmdCommand = new RelayCommand(
                () =>
                {
                    clientcom.Send(ChatName + ": " + Message);
                    ReceivedMessages.Add("YOU: " + Message);
                },
                () => {return (isConnected && Message.Length >= 1);});

        }

        private void NewMessageReceived(string message)
        {
            App.Current.Dispatcher.Invoke(
                () => { ReceivedMessages.Add(message); });
        }

        private void ClientDissconnected()
        {
            isConnected = false;
            //do this to force the update of the button visibility otherwise change is done after focus change (clicking into gui)
            CommandManager.InvalidateRequerySuggested();

        }
    }
}