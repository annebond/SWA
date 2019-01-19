using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;

namespace LegoCatalog.ViewModel
{
    public class LegoItemVm : ViewModelBase
    {
        public LegoItemVm(string description, int noOfParts, string ageRecommendation, BitmapImage image)
        {
            Description = description;
            NoOfParts = noOfParts;
            AgeRecommendation = ageRecommendation;
            Image = image;
        }

        private string description;
        private int _noOfParts;

        public string Description
        {
            get { return description; }
            set { description = value; RaisePropertyChanged(); }
        }

        public int NoOfParts
        {
            get { return _noOfParts; }
            set { _noOfParts = value; RaisePropertyChanged(); }
        }

        public string AgeRecommendation { get; set; }
        public BitmapImage Image { get; set; }

    }
}
