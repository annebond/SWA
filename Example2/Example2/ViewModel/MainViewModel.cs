using Example2.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace Example2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Server server;
        private bool isConnected = false;
        public RelayCommand StartReceiveBtnCmd { get; set; }

        private ObservableCollection<string> chatHistory;

        public ObservableCollection<string> ChatHistory
        {
            get { return chatHistory; }
            set { chatHistory = value; }
        }


        private ObservableCollection<UserVm> users = new ObservableCollection<UserVm>();

        public ObservableCollection<UserVm> Users
        {
            get { return users; }
            set { users = value; RaisePropertyChanged(); }
        }

        private UserVm currentUser;

        public UserVm CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; RaisePropertyChanged(); }
        }


        public MainViewModel()
        {
            StartReceiveBtnCmd = new RelayCommand(() =>
            {
                server = new Server(UpdatedGui, UpdateUser);
                server.StartAccepting();
                isConnected = true;
            }, () => { return !isConnected; });

            chatHistory = new ObservableCollection<string>();
        }

        public void UpdatedGui(string user, string message)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                foreach (var userVm in Users)
                {
                    if (userVm.Username == user)
                    {
                        userVm.AddMessage(message);
                    }
                }

                string chatHistoryString;
                chatHistoryString = user + " : " + message;
                chatHistory.Add(chatHistoryString);
            });
        }

        public void UpdateUser(string user)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Users.Add(new UserVm(user));
            });
        }
    }
}