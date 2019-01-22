using System.Collections.ObjectModel;
using Example7.Communication;
using Example7.ViewModel.Blueprints;
using GalaSoft.MvvmLight;

namespace Example7.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private Communication.Server server;
        public ObservableCollection<ContructionDetails> Data { get; set; }

        private ContructionDetails currentSelected;
        public ContructionDetails CurrentSelected
        {
            get { return currentSelected;}
            set { currentSelected = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            Data = new ObservableCollection<ContructionDetails>();
            server = new Server(Guiupdater);

        }

        public void Guiupdater(string obj)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] temp = obj.Split('{', '}', ';');
                    switch (temp[0])
                    {
                        // Car{ Engine; Tires; Center; Gear}5; 10:20 Example for a message from the client to the server
                        // Das versuche ich in ein neues ConstructionDetails Object in Liste hinzuzufügen
                        // ConstructionDetails erstes Element ist time -> daher das letzte (length-1) von dem text vom client
                        case "Car": Data.Add( new Car(temp[temp.Length-1], int.Parse(temp[temp.Length - 2])));
                            break;
                        case "Motorcycle": Data.Add(new Motorcycle(temp[temp.Length - 1], int.Parse(temp[temp.Length - 2])));
                            break;
                        case "Bicycle": Data.Add(new Bicycle(temp[temp.Length - 1], int.Parse(temp[temp.Length - 2])));
                            break;
                    }
                }
            );
        }
        }
    }
