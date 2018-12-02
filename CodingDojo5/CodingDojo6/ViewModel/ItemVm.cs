using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class ItemVm : ViewModelBase
    {
        public string Description { get; set; }
        public BitmapImage Image { get; set; }
        public ObservableCollection<ItemVm> Items { get; set; }
        public string AgeRecommendation { get; set; }
         
        public int NoOfParts
        {
            get
            {
                if (Items != null)
                {
                    return Items.Count;
                }
                else return 0;

            }
        }

   
        public ItemVm(string description, BitmapImage image, string rec)
        {
            Description = description;
            Image = image;
            this.AgeRecommendation = rec;         
        }

        public void AddItem(ItemVm item)
        {
            if (Items == null)
                Items = new ObservableCollection<ItemVm>();

            Items.Add(item);
        }

    }
}
