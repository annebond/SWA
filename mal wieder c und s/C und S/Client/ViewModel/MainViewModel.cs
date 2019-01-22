using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Client.ViewModel
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

        private string test="test";

        public string Test
        {
            get { return test; }
            set { test= value; }
        }


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
            Com.Client client = new Com.Client(Guiupdater);

            Btnsend = new RelayCommand(
                ()=>
                {
                    client.Send(Textsend);
                }
                , true
                );

        }

        private void Guiupdater(string obj)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    Receivedtext = obj;
                }
                );
        }
    }
}