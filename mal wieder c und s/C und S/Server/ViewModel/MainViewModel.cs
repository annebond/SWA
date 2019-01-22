using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Server.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string receivedtext;

        public string Receivedtext
        {
            get { return receivedtext; }
            set { receivedtext = value; RaisePropertyChanged(); }
        }

        public RelayCommand Btnsend { get; set; }
        public string Textsend { get; set; }

        public MainViewModel()
        {
            Com.Server server = new Com.Server(Guiupdater);

            Btnsend = new RelayCommand(
                () =>
                {
                    server.Sendtoallclients(Textsend);
                },true
                );
        }

        public void Guiupdater(string obj)
        {
            App.Current.Dispatcher.Invoke(
               ()=>
               {
                   Receivedtext = obj;
               }
               );
        }
    }
}